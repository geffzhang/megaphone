using System.Threading.Tasks;
using List.API.Events;
using Microsoft.AspNetCore.Mvc;
using List.API.Queries;
using List.API.Commands;
using Dapr;
using Dapr.Client;

namespace List.API.Controllers
{
    [ApiController]
    [Route("/")]
    public class TopicController : ControllerBase
    {
        public TopicController() : base()
        {
        }

        [Topic("resource-feed-updates")]
        [HttpPost("resource-feed-updates")]
        public async Task<IActionResult> PostAsync(ResourceEvent resourceEvent, [FromServices] DaprClient daprClient)
        {
            if (resourceEvent.Type == ResourceType.Feed)
            {
                var q = new GetListQuery();
                var items = await q.ExecuteAsync(daprClient);

                var i = items.Find(i => i.Id == resourceEvent.Id);
                if (IsNotDefault(i))
                {
                    i.LastCrawled = resourceEvent.LastCrawled;
                    i.LastHttpStatus = resourceEvent.LastStatusCode;

                    var c = new PersistListCommand(items);
                    await c.ApplyAsync(daprClient);
                }
            }

            return Ok();

            static bool IsNotDefault(Models.Item i)
            {
                return i != null && !string.IsNullOrEmpty(i.Id);
            }
        }
    }
}