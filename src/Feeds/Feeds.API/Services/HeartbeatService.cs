using Dapr.Client;
using Dapr.Client.Http;
using Feeds.API.Models.Views;
using Feeds.API.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Feeds.API.Services
{
    public class HeartbeatService : IHostedService, IDisposable
    {
        DateTimeOffset lastUpdated = DateTimeOffset.MinValue;

        private readonly FeedStorageService feedStorageService;
        private readonly DaprClient daprClient;

        private Timer timer;

        public HeartbeatService([FromServices] DaprClient daprClient)
        {
            feedStorageService = new FeedStorageService(daprClient);
            this.daprClient = daprClient;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            timer = new Timer(async state =>
            {
                await TryPushFeedUpdates();
            },
                      null,
                      TimeSpan.Zero,
                      TimeSpan.FromSeconds(30));

            return Task.CompletedTask;
        }

        private async Task TryPushFeedUpdates()
        {
            try
            {
                var q = new GetFeedListQuery();
                var entry = await q.ExecuteAsync(feedStorageService);

                if (this.lastUpdated != entry.Updated)
                {
                    if (entry.HasValue)
                    {
                        var view = new FeedListView
                        {
                            Feeds = entry.Value.Select(f => new FeedView { Display = f.Display, Url = f.Url, Id = f.Id }).ToList()
                        };

                        await daprClient.InvokeMethodAsync("api-service", "api/feeds", view, new HTTPExtension { Verb = HTTPVerb.Put });

                        this.lastUpdated = entry.Updated;
                    }
                }
            }
            catch
            {
                // nothing
            }
        }

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