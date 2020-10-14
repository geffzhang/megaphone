using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dapr.Client;
using Standard.Events;
using System.Collections.Generic;
using System;
using Standard.Extensions;
using Feeds.API.Commands;
using Feeds.API.Events;
using Feeds.API.Models;
using Feeds.API.Queries;
using System.Linq;
using Feeds.API.Services;

namespace Feeds.API.Controllers
{
    [ApiController]
    [Route("/")]
    public class QueueController : ControllerBase
    {
        private readonly DaprClient daprClient;
        private readonly FeedStorageService feedStorageService;

        public QueueController([FromServices] DaprClient daprClient) : base()
        {
            this.daprClient = daprClient;
            feedStorageService = new FeedStorageService(daprClient);
        }

        [HttpPost("feed-events")]
        public async Task<IActionResult> PostAsync(Event e)
        {
            if (e.Name == Events.Events.Feed.Add)
            {
                await AddFeed(e);
            }
            else if (e.Name == Events.Events.Feed.Delete)
            {
                await DeleteFeed(e);
            }

            return Ok();
        }

        private async Task DeleteFeed(Event e)
        {
            var q = new GetFeedListQuery();
            var entry = await q.ExecuteAsync(feedStorageService);

            if (!entry.HasValue)
            {
                entry.Value = new List<Feed>();
            }

            entry.Value = entry.Value.Where(i => i.Id != e.Parameters.GetValueOrDefault("id")).ToList();


            var c = new PersistFeedListCommand(entry);
            await c.ApplyAsync(feedStorageService);
        }

        private async Task AddFeed(Event e)
        {
            var q = new GetFeedListQuery();
            var entry = await q.ExecuteAsync(feedStorageService);
            
            if (!entry.HasValue)
            {
                entry.Value = new List<Feed>();
            }

            var feed = new Feed
            {
                Url = e.Parameters.GetValueOrDefault("url")
            };

            feed.Id = new Uri(feed.Url).ToGuid().ToString();
            entry.Value.Add(feed);

            var c = new PersistFeedListCommand(entry);
            await c.ApplyAsync(feedStorageService);

            var publish = new PublishEventCommand(EventFactory.MakeCrawlRequestEvent(feed.Url), "crawl", "crawl");
            await publish.ApplyAsync(daprClient);
        }
    }
}