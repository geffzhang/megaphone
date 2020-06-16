using System.Threading.Tasks;
using List.API.Events;
using CloudNative.CloudEvents;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using List.API.Queries;
using List.API.Commands;

namespace List.API.Controllers
{
    [ApiController]
    [Route("/")]
    public class TopicController : ControllerBase
    {
        private readonly HttpClient httpClient;
        public TopicController(IHttpClientFactory httpClientFactory) : base()
        {
            httpClient = httpClientFactory.CreateClient();
        }

        [HttpPost("resource-feed-updates")]
        public async Task<IActionResult> PostAsync(CloudEvent cloudEvent)
        {
            if (cloudEvent?.Data != null)
            {
                var e = ((JToken)cloudEvent.Data).ToObject<ResourceEvent>();

                if (e.Type == ResourceType.Feed)
                {
                    var q = new GetListQuery();
                    var items = await q.ExecuteAsync(httpClient);

                    var i = items.Find(i => i.Id == e.Id);
                    if (IsNotDefault(i))
                    {
                        i.LastCrawled = e.LastCrawled;
                        i.LastHttpStatus = e.LastStatusCode;

                        var c = new PersistListCommand(items);
                        await c.ApplyAsync(httpClient);
                    }
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