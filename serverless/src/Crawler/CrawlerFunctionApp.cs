using Crawler;
using Crawler.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Standard.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunctionApp.Crawler
{
    public static class CrawlerFunctionApp
    {
        [FunctionName("Crawl")]
        public async static Task Run([QueueTrigger("crawl-events", Connection = "AzureWebJobsStorage")] Event e,
                                     [Queue("crawl-events", Connection = "AzureWebJobsStorage")] IEnumerable<Event> events,
                                     ILogger log)
        {
            var crawler = new WebResourceCrawler();
            var resource = await crawler.GetResourceAsync(new Uri(e.Parameters["url"]));

            if (e.Data.Any())
            {
                var r = e.Data["resource"];

                resource.Description = r["description"];
                resource.Display = r["display"];
                resource.Published = DateTimeOffset.Parse(r["published"]);
            }

            if (resource.Type == ResourceType.Feed)
            {
                events = resource.Resources.Select(r => EventFactory.MakeCrawlRequestEvent(r)).ToList();
            }

            log.LogInformation($"Crawl Request processed: {e}");

        }
    }
}
