using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dapr;
using Dapr.Client;
using Feeds.API.Commands;
using Feeds.API.Queries;
using Standard.Events;
using System;
using Feeds.API.Models;
using System.Collections.Generic;

namespace Feeds.API.Controllers
{

    [ApiController]
    [Route("/")]
    public class TopicController : ControllerBase
    {
        public TopicController() : base()
        {
        }

        [Topic("resource-updates")]
        [HttpPost("resource-updates")]
        public async Task<IActionResult> PostAsync(Event e, [FromServices] DaprClient daprClient)
        {
            if (e.Name == Events.Events.Resource.Update)
            {
                if (e.Data.ContainsKey("resource"))
                {
                    var d = e.Data["resource"];

                    if (d["type"] == ResourceType.Feed)
                    {
                        await UpdateFeed(e, daprClient, d);
                    }
                }
            }

            return Ok();                  
        }
        static bool IsNotDefault(Feed i)
        {
            return i != null && !string.IsNullOrEmpty(i.Id);
        }

        static async Task UpdateFeed(Event e, DaprClient daprClient, Dictionary<string,string> d)
        {
            var q = new GetFeedListQuery();
            var items = await q.ExecuteAsync(daprClient);

            var i = items.Find(i => i.Id == d["id"]);
            if (IsNotDefault(i))
            {
                i.LastCrawled = DateTimeOffset.Parse(e.Metadata["updated"]);
                i.LastHttpStatus = Convert.ToInt32(e.Metadata["status"]);
                i.Display = d["display"];

                var c = new PersistFeedListCommand(items);
                await c.ApplyAsync(daprClient);
            }
        }
    }
}