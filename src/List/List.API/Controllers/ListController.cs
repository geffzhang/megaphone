using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using List.API.Commands;
using List.API.Events;
using List.API.Models;
using List.API.Queries;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Standard.Extensions;

namespace List.API.Controllers
{

    [ApiController]
    [EnableCors]
    [Route("/api/list")]
    public class ListController : ControllerBase
    {
        private readonly HttpClient httpClient;
        public ListController(IHttpClientFactory httpClientFactory) : base()
        {
            httpClient = httpClientFactory.CreateClient();
        }

        [Route("")]
        [HttpPost]
        public async Task<CreatedAtActionResult> PostAsync(Item item)
        {
            var q = new GetListQuery();
            var items = await q.ExecuteAsync(httpClient);

            item.Id = new Uri(item.Url).ToGuid().ToString();
            items.Add(item);

            var c = new PersistListCommand(items);
            await c.ApplyAsync(httpClient);

            var publish = new PublishEventCommand(new CrawlRequestEvent { Url = item.Url }, "crawl");
            await publish.ApplyAsync(httpClient);

            return new CreatedAtActionResult("Get", "List", new { id = item.Id }, item);
        }

        [Route("")]
        [HttpGet]
        public async Task<JsonResult> GetAsync()
        {
            var q = new GetListQuery();
            var items = await q.ExecuteAsync(httpClient);
            return new JsonResult(items);
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetAsync(string id)
        {
            var q = new GetListQuery();
            var items = await q.ExecuteAsync(httpClient);

            var item = items.FirstOrDefault(i => i.Id == id);

            return new JsonResult(item);
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var q = new GetListQuery();
            var items = await q.ExecuteAsync(httpClient);

            items = items.Where(i => i.Id != id).ToList();

            var c = new PersistListCommand(items);
            await c.ApplyAsync(httpClient);

            return Ok();
        }
    }
}
