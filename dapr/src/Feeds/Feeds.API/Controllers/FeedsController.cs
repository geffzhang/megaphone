using System.Linq;
using System.Threading.Tasks;
using Dapr.Client;
using Feeds.API.Queries;
using Feeds.API.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Feeds.API.Controllers
{
    [ApiController]
    [EnableCors]
    [Route("/api/feeds")]
    public class FeedsController : ControllerBase
    {
        private FeedStorageService feedStorageService;

        public FeedsController([FromServices] DaprClient daprClient)
        {
            feedStorageService = new FeedStorageService(daprClient);
        }

        [Route("")]
        [HttpGet]
        public async Task<JsonResult> GetAsync()
        {
            var q = new GetFeedListQuery();
            var entry = await q.ExecuteAsync(feedStorageService);

            return new JsonResult(entry.Value);
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetAsync(string id)
        {
            var q = new GetFeedListQuery();
            var entry = await q.ExecuteAsync(feedStorageService);

            var feed = entry.Value.FirstOrDefault(i => i.Id == id);

            return new JsonResult(feed);
        }
    }
}
