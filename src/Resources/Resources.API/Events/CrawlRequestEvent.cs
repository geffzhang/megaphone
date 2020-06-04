using System.Text.Json.Serialization;

namespace Resources.API.Events
{
    public class CrawlRequestEvent
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
