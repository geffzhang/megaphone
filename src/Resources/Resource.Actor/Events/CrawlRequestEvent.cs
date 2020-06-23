using System.Text.Json.Serialization;

namespace Resource.Actor.Events
{
    public class CrawlRequestEvent
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
