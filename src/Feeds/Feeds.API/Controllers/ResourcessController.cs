using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapr.Client;
using Feeds.API.Queries;
using Feeds.API.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Feeds.API.Controllers
{
    [ApiController]
    [EnableCors]
    [Route("/api/resources")]
    public class ResourcesController : ControllerBase
    {
        [Route("{year}/{month}/{day}")]
        [HttpGet]
        public async Task<JsonResult> GetAsync([FromServices] DaprClient daprClient, int year, int month, int day)
        {
            var storage = new ResourceStorageService(daprClient);

            var q = new GetResourceListQuery(new DateTime(year, month, day));
            var entry = await q.ExecuteAsync(storage);

            return new JsonResult(entry.Value ?? new List<Models.Resource>());
        }
    }
}
