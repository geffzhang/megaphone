using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using List.API.Commands;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Resources.API.Commands;
using Resources.API.Events;
using Resources.API.Models;
using Resources.API.Queries;
using Standard.Extensions;

namespace Resources.API.Controllers
{
    [ApiController]
    [EnableCors]
    [Route("/api/list")]
    public class ResourcesController : ControllerBase
    {
        private readonly HttpClient httpClient;
        public ResourcesController(IHttpClientFactory httpClientFactory) : base()
        {
            httpClient = httpClientFactory.CreateClient();
        }

        [Route("")]
        [HttpPost]
        public async Task<CreatedAtActionResult> PostAsync(Resource item)
        {
            var q = new GetListQuery("<id>");
            var items = await q.ExecuteAsync(httpClient);

            item.Id = new Uri(item.Url).ToGuid().ToString();
            items.Add(item);

            var c = new PersistResourceCommand(items, "<id>");
            await c.ApplyAsync(httpClient);

            var publish = new PublishEventCommand(new CrawlRequestEvent { Url = item.Url }, "crawl");
            await publish.ApplyAsync(httpClient);

            return new CreatedAtActionResult("Get", "List", new { id = item.Id }, item);
        }

        [Route("")]
        [HttpGet]
        public async Task<JsonResult> GetAsync()
        {
            var q = new GetListQuery("<id>");
            var items = await q.ExecuteAsync(httpClient);
            return new JsonResult(items);
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetAsync(string id)
        {
            var q = new GetListQuery("<id>");
            var items = await q.ExecuteAsync(httpClient);

            var item = items.FirstOrDefault(i => i.Id == id);

            return new JsonResult(item);
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var q = new GetListQuery("<id>");
            var items = await q.ExecuteAsync(httpClient);

            items = items.Where(i => i.Id != id).ToList();

            var c = new PersistResourceCommand(items, "<id>");
            await c.ApplyAsync(httpClient);

            return Ok();
        }
    }
}
