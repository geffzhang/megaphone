using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using List.API.Commands;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Resources.API.Commands;
using Resources.API.Events;
using Resources.API.Models;
using Resources.API.Queries;
using Standard.Extensions;

namespace Resources.API.Controllers
{
    [ApiController]
    [EnableCors]
    [Route("/api/resources")]
    public class ResourcesController : ControllerBase
    {
        private readonly HttpClient httpClient;
        public ResourcesController(IHttpClientFactory httpClientFactory) : base()
        {
            httpClient = httpClientFactory.CreateClient();
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> PutAsync(string id, ResourceRepresentation resource)
        {
            try
            {
                var r = await GetResourceOrDefault(id);

                Update(r, resource);

                var c = new PersistResourceCommand(r, id);
                await c.ApplyAsync(httpClient);

                var publish = new PublishEventCommand(new ResourceEvent
                {
                    Event = "update",
                    Id = r.Id,
                    LastCrawled = DateTimeOffset.UtcNow,
                    LastStatusCode = r.StatusCode,
                    Url = Url.Action("Get", new { id = resource.Id }),
                    Type = r.Type

                }, "resource-events");

                await publish.ApplyAsync(httpClient);

                return new OkObjectResult(resource);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private async Task<Resource> GetResourceOrDefault(string id)
        {
            var q = new GetResourceQuery(id);
            var r = await q.ExecuteAsync(httpClient);
            return r;
        }

        private static void Update(Resource r, ResourceRepresentation resource)
        {
            r.Id = resource.Id;
            r.Self = resource.Self;
            r.StatusCode = resource.StatusCode;

            if (resource.IsActive)
            {
                r.Created = resource.Created;
                r.Published = resource.Published;
                r.Type = resource.Type;
                r.Description = resource.Description;
                r.Display = resource.Display;
            }
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<JsonResult> GetAsync(string id)
        {
            var q = new GetResourceQuery(id);
            var r = await q.ExecuteAsync(httpClient);
            return new JsonResult(r);
        }

        // [Route("{id}")]
        // [HttpGet]
        // public async Task<IActionResult> GetAsync(string id)
        // {
        //     var q = new GetListQuery("<id>");
        //     var items = await q.ExecuteAsync(httpClient);

        //     var item = items.FirstOrDefault(i => i.Id == id);

        //     return new JsonResult(item);
        // }

        // [Route("{id}")]
        // [HttpDelete]
        // public async Task<IActionResult> DeleteAsync(string id)
        // {
        //     var q = new GetListQuery("<id>");
        //     var items = await q.ExecuteAsync(httpClient);

        //     items = items.Where(i => i.Id != id).ToList();

        //     var c = new PersistResourceCommand(items, "<id>");
        //     await c.ApplyAsync(httpClient);

        //     return Ok();
        // }
    }
}
