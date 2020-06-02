using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Crawler.API.Controllers
{
    [ApiController]
    [Route("/api/crawler")]
    public class CrawlerController : ControllerBase
    {
        [Route("")]
        [HttpPost]
        public async Task<JsonResult> PostAsync([FromBody]string url)
        {
            var crawler = new WebResourceCrawler();
            var resource = await crawler.GetResourceAsync(new Uri(url));

            return new JsonResult(resource);
        }
    }
}