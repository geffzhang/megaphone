using System.Text.Json.Serialization;

namespace Crawler.API.Commands
{
    public class CrawlRequestEvent
    {
        [JsonPropertyName("url")]
        public string Url {get;set;}
    }
}