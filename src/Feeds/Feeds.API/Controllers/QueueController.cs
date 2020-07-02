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

namespace Feeds.API.Controllers
{
    [ApiController]
    [Route("/")]
    public class QueueController : ControllerBase
    {
        DaprClient daprClient;
        public QueueController([FromServices] DaprClient daprClient) : base()
        {
            this.daprClient = daprClient;
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
            var items = await q.ExecuteAsync(daprClient);

            items = items.Where(i => i.Id != e.Parameters.GetValueOrDefault("id")).ToList();

            var c = new PersistFeedListCommand(items);
            await c.ApplyAsync(daprClient);
        }

        private async Task AddFeed(Event e)
        {
            var q = new GetFeedListQuery();
            var items = await q.ExecuteAsync(daprClient);

            var item = new Feed
            {
                Url = e.Parameters.GetValueOrDefault("url")
            };

            item.Id = new Uri(item.Url).ToGuid().ToString();
            items.Add(item);

            var c = new PersistFeedListCommand(items);
            await c.ApplyAsync(daprClient);

            var publish = new PublishEventCommand(EventFactory.MakeCrawlRequestEvent(item.Url), "crawl");
            await publish.ApplyAsync(daprClient);
        }
    }
}