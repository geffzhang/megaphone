using System;
using System.Linq;
using System.Threading.Tasks;
using Dapr.Client;
using Feeds.API.Commands;
using Feeds.API.Events;
using Feeds.API.Models;
using Feeds.API.Queries;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Standard.Extensions;

namespace Feeds.API.Controllers
{
    [ApiController]
    [EnableCors]
    [Route("/api/feeds")]
    public class FeedsController : ControllerBase
    {
        [Route("")]
        [HttpGet]
        public async Task<JsonResult> GetAsync([FromServices] DaprClient daprClient)
        {
            var q = new GetFeedListQuery();
            var items = await q.ExecuteAsync(daprClient);
            return new JsonResult(items);
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetAsync(string id, [FromServices] DaprClient daprClient)
        {
            var q = new GetFeedListQuery();
            var items = await q.ExecuteAsync(daprClient);

            var item = items.FirstOrDefault(i => i.Id == id);

            return new JsonResult(item);
        }
    }
}
