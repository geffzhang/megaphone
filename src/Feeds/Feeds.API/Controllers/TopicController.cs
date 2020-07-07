using Dapr;
using Dapr.Client;
using Feeds.API.Commands;
using Feeds.API.Events;
using Feeds.API.Models;
using Feeds.API.Services;
using Microsoft.AspNetCore.Mvc;
using Standard.Events;
using System.Threading.Tasks;

namespace Feeds.API.Controllers
{
    [ApiController]
    [Route("/")]
    public class TopicController : ControllerBase
    {
        private readonly ResourceStorageService resourceStorageService;

        private readonly FeedStorageService feedStorageService;

        public TopicController([FromServices] DaprClient daprClient)
        {
            resourceStorageService = new ResourceStorageService(daprClient);
            feedStorageService = new FeedStorageService(daprClient);
        }

        [Topic("resource-updates")]
        [HttpPost("resource-updates")]
        public async Task<IActionResult> PostAsync(Event e)
        {
            if (e.Name == Events.Events.Resource.Update)
            {
                if (e.TryConvertToFeed(out var f))
                    await UpdateFeed(f);
                else if (e.TryConvertToResource(out var r))
                    await UpsertResource(r);
            }
            return Ok();
        }

        private async Task UpsertResource(Resource r)
        {
            var c = new UpsertResourceListCommand(r);
            await c.ApplyAsync(resourceStorageService);            
        }

        private async Task UpdateFeed(Feed f)
        {
            var c = new UpdateFeedListCommand(f);
            await c.ApplyAsync(feedStorageService);
        }
    }
}