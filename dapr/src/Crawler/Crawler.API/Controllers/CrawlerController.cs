using System;
using System.Threading.Tasks;
using Crawler.API.Commands;
using Microsoft.AspNetCore.Mvc;
using CloudNative.CloudEvents;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Linq;
using Standard.Events;
using Microsoft.Extensions.Primitives;

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
        public async Task<OkResult> PostAsync(CloudEvent cloudEvent)
        {
            String Traceparent = string.Empty;

            if (this.Request.Headers.TryGetValue("traceparent", out StringValues values))
                Traceparent = values.FirstOrDefault();

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
                foreach (var r in resource.Resources)
                {
                    var publish = new PublishEventCommand(EventFactory.MakeCrawlRequestEvent(r), "crawl", Traceparent);
                    await publish.ApplyAsync(httpClient);
                }
            }

            return Ok();
        }  
        
        async Task UpdateResource(Models.Resource resource)
        {
           var c = new UpdateResourceCommand(resource);
           await c.ApplyAsync(httpClient);
        }
    }
}