using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapr;
using Dapr.Client;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Crawler.API.Controllers
{
    public class Item
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    [ApiController]
    [EnableCors]
    [Route("/api/crawler/watch")]
    public class WatchController : ControllerBase
    {
        const string STORENAME = "crawler-state-store";
        const string STORELISTKEY = "crawler-state-store";

        [Route("")]
        [HttpPost]
        public async Task<CreatedAtActionResult> PostAsync([FromServices] DaprClient daprClient, Item item)
        {
            var stateEntity = await daprClient.GetStateEntryAsync<List<Item>>(STORENAME, STORELISTKEY);
            var watchItems = stateEntity.Value ?? new List<Item>();

            item.Id = Guid.NewGuid().ToString();

            watchItems.Add(item);
            stateEntity.Value = watchItems;
            await stateEntity.TrySaveAsync();

            return new CreatedAtActionResult("Get", "Watch", new { id = item.Id }, item);
        }

        [Route("")]
        [HttpGet]
        public async Task<JsonResult> GetAsync([FromServices] DaprClient daprClient)
        {
            var stateEntity = await daprClient.GetStateEntryAsync<List<Item>>(STORENAME, STORELISTKEY);
            var watchItems = stateEntity.Value ?? new List<Item>();
            return new JsonResult(watchItems);
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromServices] DaprClient daprClient, string id)
        {
            var stateEntity = await daprClient.GetStateEntryAsync<List<Item>>(STORENAME, STORELISTKEY);
            var watchItems = stateEntity.Value ?? new List<Item>();

            var item = watchItems.FirstOrDefault(i => i.Id == id);

            if (item == null)
                return NotFound();

            return new JsonResult(item);
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromServices] DaprClient daprClient, string id)
        {
            var stateEntity = await daprClient.GetStateEntryAsync<List<Item>>(STORENAME, STORELISTKEY);
            var watchItems = stateEntity.Value ?? new List<Item>();

            stateEntity.Value = watchItems.Where(i => i.Id != id).ToList();

            if (watchItems.Count == stateEntity.Value.Count)
                return NotFound();

            await stateEntity.TrySaveAsync();

            return Ok();
        }
    }
}