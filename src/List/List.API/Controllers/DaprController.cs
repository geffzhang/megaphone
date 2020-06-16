﻿using Microsoft.AspNetCore.Mvc;

namespace List.API.Controllers
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
                    Topic = "resource-feed-updates",
                    Route = "/resource-feed-updates"
                }
                });
        }
    }
}