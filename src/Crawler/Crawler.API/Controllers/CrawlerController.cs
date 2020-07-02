using System;
using System.Threading.Tasks;
using Crawler.API.Commands;
using Microsoft.AspNetCore.Mvc;
using CloudNative.CloudEvents;
using Newtonsoft.Json.Linq;
using Crawler.Models;
using System.Net.Http;
using System.Linq;
using Standard.Events;

namespace Crawler.API.Controllers
{
    [ApiController]
    [Route("crawl")]
    public class CrawlerController : ControllerBase
    {
        private readonly HttpClient httpClient;
        public CrawlerController(IHttpClientFactory httpClientFactory) : base()
        {
            httpClient = httpClientFactory.CreateClient();
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(CloudEvent cloudEvent)
        {
            var e = ((JToken)cloudEvent.Data).ToObject<Event>();

            var crawler = new WebResourceCrawler();
            var resource = await crawler.GetResourceAsync(new Uri(e.Parameters["url"]));

            if (e.Data.Any())
            {
                var r = e.Data["resource"];

                resource.Description = r["description"];
                resource.Display = r["display"];
                resource.Published = DateTimeOffset.Parse(r["published"]);
            }

            await UpdateResource(resource);

            if (resource.Type == ResourceType.Feed)
            {
                var resources = await crawler.GetChildResourcesAsync(resource);

                foreach (var r in resources)
                {
                    var publish = new PublishEventCommand(EventFactory.MakeCrawlRequestEvent(r), "crawl"); ;
                    await publish.ApplyAsync(httpClient);
                }
            }

            return Ok();

            async Task UpdateResource(Crawler.Models.Resource resource)
            {
                var c = new UpdateResourceCommand(resource);
                await c.ApplyAsync(httpClient);
            }
        }
    }
}