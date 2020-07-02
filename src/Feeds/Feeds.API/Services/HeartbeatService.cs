using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;
using Dapr.Client;
using Feeds.API.Commands;
using Feeds.API.Events;
using Feeds.API.Models;
using System.Collections.Generic;
using System.Linq;
using Dapr.Client.Http;

namespace Feeds.API.Services
{
    public class HeartbeatService : IHostedService, IDisposable
    {
        const string STORENAME = "feed-state-store";
        const string STOREKEY = "feed-list";

        string feedListEtag = String.Empty;

        private Timer timer;
        private readonly DaprClient daprClient;

        public HeartbeatService([FromServices] DaprClient daprClient)
        {
            this.daprClient = daprClient;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            timer = new Timer(async state =>
                      {
                          try
                          {
                              var s = await daprClient.GetStateEntryAsync<List<Feed>>(STORENAME, STOREKEY);
                              if (this.feedListEtag != s.ETag)
                              {
                                  if (s.Value != null)
                                  {
                                      var view = new FeedListView();
                                      view.Feeds = s.Value.Select(f => new FeedView { Display = f.Display, Url = f.Url }).ToList();

                                      await daprClient.InvokeMethodAsync("api-service", "api/feeds", view, new HTTPExtension { Verb = HTTPVerb.Put });
                                     
                                      this.feedListEtag = s.ETag;
                                  }
                              }
                          }
                          catch
                          {
                              // nothing
                          }
                      },
                      null,
                      TimeSpan.Zero,
                      TimeSpan.FromSeconds(30));

            return Task.CompletedTask;
        }

        private async Task PublishCrawlRequest(Feed i)
        {
            var c = new PublishEventCommand(EventFactory.MakeCrawlRequestEvent(i.Url), "crawl");
            await c.ApplyAsync(daprClient);
        }

        private static bool IsDueForCrawl(Feed i) => i.LastCrawled < DateTimeOffset.UtcNow.Subtract(TimeSpan.FromMinutes(20));

        public Task StopAsync(CancellationToken stoppingToken)
        {
            timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            timer?.Dispose();
        }
    }
}