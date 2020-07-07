using Dapr.Client;
using Dapr.Client.Http;
using Feeds.API.Models.Views;
using Feeds.API.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Feeds.API.Services
{
    public class HeartbeatService : IHostedService, IDisposable
    {
        DateTimeOffset lastUpdated = DateTimeOffset.MinValue;

        private readonly FeedStorageService feedStorageService;
        private readonly ResourceStorageService resourceStorageService;
        private readonly ResourceListChangeTracker resourceTracker;

        private readonly DaprClient daprClient;

        private Timer timer;

        public HeartbeatService([FromServices] DaprClient daprClient,
                                [FromServices] ResourceListChangeTracker resourceTracker)
        {
            feedStorageService = new FeedStorageService(daprClient);
            resourceStorageService = new ResourceStorageService(daprClient);

            this.daprClient = daprClient;
            this.resourceTracker = resourceTracker;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            timer = new Timer(async state =>
            {
                var tasks = new[] { TryPushFeedUpdates(), TryPushResourceListUpdates() };
                await Task.WhenAll(tasks);
            },
                      null,
                      TimeSpan.Zero,
                      TimeSpan.FromSeconds(30));

            return Task.CompletedTask;
        }

        private async Task TryPushResourceListUpdates()
        {
            List<DateTime> dates = GetDates();

            foreach (var d in dates)
            {
                var q = new GetResourceListQuery(d);
                var entry = await q.ExecuteAsync(resourceStorageService);

                var view = new ResourceListView
                {
                    Date = d,
                    Resources = entry.Value.Select(r => new ResourceView
                    {
                        Display = r.Display,
                        Url = r.Url,
                        Id = r.Id
                    }).ToList()
                };

                await daprClient.InvokeMethodAsync("api-service", "api/resources", view, new HTTPExtension { Verb = HTTPVerb.Put });
            }
        }

        private List<DateTime> GetDates()
        {
            List<DateTime> dates = new List<DateTime>();
            while (resourceTracker.TryRemoveDate(out DateTime date))
            {
                dates.Add(date.Date);
            }

            dates = dates.Distinct().ToList();
            return dates;
        }

        private async Task TryPushFeedUpdates()
        {
            try
            {
                var q = new GetFeedListQuery();
                var entry = await q.ExecuteAsync(feedStorageService);

                if (this.lastUpdated != entry?.Updated)
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