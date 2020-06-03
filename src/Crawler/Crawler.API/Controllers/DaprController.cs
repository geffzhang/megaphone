using Microsoft.AspNetCore.Mvc;

namespace Crawler.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DaprController : ControllerBase
    {
        // TODO: Challenge 2
        [HttpGet("subscribe")]
        public IActionResult GetTask()
        {
            return Ok(new[]
            { "crawl"
                // new {
                //     Topic = "order",
                //     Route = "/order"
                // }
            });
        }        
    }
}