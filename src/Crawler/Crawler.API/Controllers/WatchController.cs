using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Crawler.API.Commands;
using Crawler.API.Models;
using Crawler.API.Queries;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Standard.Extensions;

namespace Crawler.API.Controllers
{
    [ApiController]
    [EnableCors]
    [Route("/api/crawler/watch")]
    public class WatchListController : ControllerBase
    {
        private readonly HttpClient httpClient;
        public WatchListController(IHttpClientFactory httpClientFactory) : base()
        {
            httpClient = httpClientFactory.CreateClient();
        }

        [Route("")]
        [HttpPost]
        public async Task<CreatedAtActionResult> PostAsync(Item item)
        {
            var q = new GetWatchListQuery();
            var items = await q.ExecuteAsync(this.httpClient);

            item.Id = new Uri(item.Url).ToGuid().ToString();
            items.Add(item);

            var c = new PersistWatchListCommand(items);
            await c.ApplyAsync(this.httpClient);

            var publish = new PublishEventCommand(new CrawlRequestEvent { Url = item.Url }, "crawl");
            await publish.ApplyAsync(this.httpClient);

            return new CreatedAtActionResult("Get", "WatchList", new { id = item.Id }, item);
        }

        [Route("")]
        [HttpGet]
        public async Task<JsonResult> GetAsync()
        {
            var q = new GetWatchListQuery();
            var items = await q.ExecuteAsync(this.httpClient);
            return new JsonResult(items);
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetAsync(string id)
        {
            var q = new GetWatchListQuery();
            var items = await q.ExecuteAsync(this.httpClient);

            var item = items.FirstOrDefault(i => i.Id == id);

            return new JsonResult(item);
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var q = new GetWatchListQuery();
            var items = await q.ExecuteAsync(this.httpClient);

            items = items.Where(i => i.Id != id).ToList();

            var c = new PersistWatchListCommand(items);
            await c.ApplyAsync(this.httpClient);

            return Ok();
        }
    }
}