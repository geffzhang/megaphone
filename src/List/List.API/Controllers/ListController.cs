using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Dapr.Client;
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
        public async Task<CreatedAtActionResult> PostAsync(Item item, [FromServices] DaprClient daprClient)
        {
            var q = new GetListQuery();
            var items = await q.ExecuteAsync(daprClient);

            item.Id = new Uri(item.Url).ToGuid().ToString();
            items.Add(item);

            var c = new PersistListCommand(items);
            await c.ApplyAsync(daprClient);

            var publish = new PublishEventCommand(new CrawlRequestEvent { Url = item.Url }, "crawl");
            await publish.ApplyAsync(daprClient);

            return new CreatedAtActionResult("Get", "List", new { id = item.Id }, item);
        }

        [Route("")]
        [HttpGet]
        public async Task<JsonResult> GetAsync([FromServices] DaprClient daprClient)
        {
            var q = new GetListQuery();
            var items = await q.ExecuteAsync(daprClient);
            return new JsonResult(items);
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetAsync(string id, [FromServices] DaprClient daprClient)
        {
            var q = new GetListQuery();
            var items = await q.ExecuteAsync(daprClient);

            var item = items.FirstOrDefault(i => i.Id == id);

            return new JsonResult(item);
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(string id, [FromServices] DaprClient daprClient)
        {
            var q = new GetListQuery();
            var items = await q.ExecuteAsync(daprClient);

            items = items.Where(i => i.Id != id).ToList();

            var c = new PersistListCommand(items);
            await c.ApplyAsync(daprClient);

            return Ok();
        }
    }
}
