using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Resources.API.Commands;
using Resources.API.Events;
using Resources.API.Models;
using Resources.API.Queries;

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

                }, topic: GetTopic(r));

                await publish.ApplyAsync(httpClient);

                return new OkObjectResult(resource);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private static string GetTopic(Resource r)
        {
            var topic = string.Empty;

            switch (r.Type)
            {
                case ResourceType.Feed:
                    topic = "resource-feed-updates";
                    break;
                case ResourceType.Page:
                    topic = "resource-updates";
                    break;
                
            }

            return topic;
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
            var r = await GetResourceOrDefault(id);
            return new JsonResult(r);
        }
    }
}
