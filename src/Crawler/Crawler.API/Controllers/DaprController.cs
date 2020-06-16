using Microsoft.AspNetCore.Mvc;

namespace Crawler.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DaprController : ControllerBase
    {
        [HttpGet("subscribe")]
        public IActionResult GetTask()
        {
            return Ok(new[]
            { 
                new {
                    Topic = "crawl",
                    Route = "/crawl"
                }
            });
        }        
    }
}