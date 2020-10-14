using System.Collections.Generic;
using System.Threading.Tasks;
using Dapr.Client;
using Megaphone.API.Events;
using Megaphone.API.Models;
using Megaphone.API.Models.Representations;
using Megaphone.API.Models.Views;
using Microsoft.AspNetCore.Mvc;

namespace Megaphone.API.Controllers
{
    [ApiController]
    [Route("api/feeds")]
    public class FeedController : ControllerBase
    {
        private readonly DaprClient daprClient;

        public FeedController([FromServices] DaprClient daprClient)
        {
            this.daprClient = daprClient;
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> PostAsync(NewFeed newFeed)
        {
            var e = EventFactory.MakeAddFeedEvent(newFeed.Url);

            await daprClient.InvokeBindingAsync("feed-events", "create", e);

            return Accepted();
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var e = EventFactory.MakeDeleteFeedEvent(id);

            await daprClient.InvokeBindingAsync("feed-events", "create", e);
            
            return Accepted();
        }

        [Route("")]
        [HttpPut]
        public async Task<IActionResult> PutAsync(FeedListView view)
        {
            await daprClient.SaveStateAsync("api-state-store", "list", view);
            return Ok();
        }

        [Route("")]
        [HttpGet]
        public async Task<JsonResult> GetAsync()
        {
            var view = await daprClient.GetStateAsync<FeedListView>("api-state-store", "list");
            if (view == null)
                view = new FeedListView() { Feeds = new List<FeedView>() };
            
            var r = RepresentationFactory.MakeFeedListRepresentation(view);
                        
            return new JsonResult(r);
        }
    }
}
