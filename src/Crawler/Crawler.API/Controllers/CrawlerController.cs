using System;
using System.Threading.Tasks;
using Crawler.API.Commands;
using Microsoft.AspNetCore.Mvc;
using CloudNative.CloudEvents;
using Newtonsoft.Json.Linq;
using Crawler.Models;
using System.Net.Http;
using System.Linq;

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
            var e = ((JToken)cloudEvent.Data).ToObject<CrawlRequestEvent>();

            var crawler = new WebResourceCrawler();
            var resource = await crawler.GetResourceAsync(new Uri(e.Url));

            if (e.HasValues)
            {
                resource.Description = e.Description;
                resource.Display = e.Display;
                resource.Published = e.Published;
            }

            await UpdateResource(resource);

            if (resource.Type == ResourceType.Feed)
            {
                var resources = await crawler.GetChildResourcesAsync(resource);

                foreach(var r in resources){
                    var publish = new PublishEventCommand(
                    new CrawlRequestEvent
                    {
                        Url = r.Self.ToString(),
                        Published  = r.Published,
                        Display = r.Display,
                        Description = r.Description
                    }, "crawl");
                    await publish.ApplyAsync(httpClient);
                }
            }

            return Ok();

            async Task UpdateResource(Resource resource)
            {
                var c = new UpdateResourceCommand(resource);
                await c.ApplyAsync(httpClient);
            }
        }
    }
}