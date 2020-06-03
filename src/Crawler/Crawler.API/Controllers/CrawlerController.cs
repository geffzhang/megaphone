using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crawler.API.Commands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CloudNative.CloudEvents;
using Newtonsoft.Json.Linq;
using Crawler.Models;

namespace Crawler.API.Controllers
{
    [ApiController]
    [Route("crawl")]
    public class CrawlerController : ControllerBase
    {
        [HttpPost]
        public async Task<JsonResult> PostAsync(CloudEvent cloudEvent)
        {
            var e = ((JToken)cloudEvent.Data).ToObject<CrawlRequestEvent>();
            var crawler = new WebResourceCrawler();
            var resource = await crawler.GetResourceAsync(new Uri(e.Url));

            if(resource.Type == ResourceType.Feed){
                var rerources = await crawler.GetChildResourcesAsync(resource);                
            }

            return new JsonResult("");

    }
}
}