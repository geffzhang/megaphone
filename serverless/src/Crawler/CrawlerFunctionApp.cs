using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Crawler
{
    public static class CrawlerFunctionApp
    {
        [FunctionName("Function1")]
        public static void Run([QueueTrigger("crawl-events", Connection = "")] string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
