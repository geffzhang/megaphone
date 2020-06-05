using System;
using System.Threading.Tasks;
using Crawler.API.Commands;
using Microsoft.AspNetCore.Mvc;
using CloudNative.CloudEvents;
using Newtonsoft.Json.Linq;
using Crawler.Models;
using System.Net.Http;

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

            await UpdateResource(resource);

            if (resource.Type == ResourceType.Feed)
            {
                var resources = await crawler.GetChildResourcesAsync(resource);

                foreach (var r in resources)
                    await UpdateResource(r);
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