using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using List.API.Commands;
using List.API.Events;
using List.API.Models;
using List.API.Queries;
using Microsoft.AspNetCore.Mvc;
using Dapr.Client;

namespace List.API.Services
{
    public class HeartbeatService : IHostedService, IDisposable
    {
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
                              var q = new GetListQuery();
                              var items = await q.ExecuteAsync(daprClient);

                              foreach (var i in items)
                                  if (IsDueForCrawl(i))
                                      await PublishCrawlRequest(i);
                          }
                          catch
                          {
                              // nothing
                          }
                      },
                      null,
                      TimeSpan.Zero,
                      TimeSpan.FromSeconds(60*15));

            return Task.CompletedTask;
        }

        private async Task PublishCrawlRequest(Item i)
        {
            var c = new PublishEventCommand(new CrawlRequestEvent { Url = i.Url }, "crawl");
            await c.ApplyAsync(daprClient);
        }

        private static bool IsDueForCrawl(Item i) => i.LastCrawled < DateTimeOffset.UtcNow.Subtract(TimeSpan.FromMinutes(20));

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