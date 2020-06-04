using System.Text.Json.Serialization;

namespace List.API.Events
{
    public class CrawlRequestEvent
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
