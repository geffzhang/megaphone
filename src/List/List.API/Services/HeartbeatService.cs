using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using List.API.Commands;
using List.API.Events;
using List.API.Models;
using List.API.Queries;

namespace List.API.Services
{
    public class HeartbeatService : IHostedService, IDisposable
    {
        private Timer timer;
        private readonly HttpClient httpClient;
        public HeartbeatService(IHttpClientFactory httpClientFactory)
        {
            httpClient = httpClientFactory.CreateClient();
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            timer = new Timer(async state =>
                      {
                          try
                          {
                              var q = new GetListQuery();
                              var items = await q.ExecuteAsync(httpClient);

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
                      TimeSpan.FromSeconds(60));

            return Task.CompletedTask;
        }

        private async Task PublishCrawlRequest(Item i)
        {
            var c = new PublishEventCommand(new CrawlRequestEvent { Url = i.Url }, "crawl");
            await c.ApplyAsync(httpClient);
        }

        private static bool IsDueForCrawl(Item i) => i.LastCrawled > DateTimeOffset.UtcNow.Subtract(TimeSpan.FromMinutes(15));

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