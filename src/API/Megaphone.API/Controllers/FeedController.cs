using System.Threading.Tasks;
using Dapr.Client;
using Megaphone.API.Events;
using Megaphone.API.Models;
using Megaphone.API.Models.Representations;
using Microsoft.AspNetCore.Mvc;

namespace Megaphone.API.Controllers
{
    [ApiController]
    [Route("api/feeds")]
    public class FeedController : ControllerBase
    {
        [Route("")]
        [HttpPost]
        public async Task<IActionResult> PostAsync(NewFeed newFeed, [FromServices] DaprClient daprClient)
        {

            var e = EventFactory.MakeAddFeedEvent(newFeed.Url);

            await daprClient.InvokeBindingAsync("feed-events", "create", e);

            return Accepted();
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(string id, [FromServices] DaprClient daprClient)
        {
            var e = EventFactory.MakeDeleteFeedEvent(id);

            await daprClient.InvokeBindingAsync("feed-events", "create", e);
            
            return Accepted();
        }

        [Route("")]
        [HttpPut]
        public async Task<IActionResult> PutAsync(FeedListView view, [FromServices] DaprClient daprClient)
        {
            await daprClient.SaveStateAsync("api-state-store", "list", view);
            return Ok();
        }

        [Route("")]
        [HttpGet]
        public async Task<JsonResult> GetAsync([FromServices] DaprClient daprClient)
        {
            var view = await daprClient.GetStateAsync<FeedListView>("api-state-store", "list");

            var r = RepresentationFactory.MakeFeedListRepresentation(view);
            
            return new JsonResult(r);
        }
    }
}
