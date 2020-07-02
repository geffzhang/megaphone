using System;
using System.Text.Json.Serialization;

namespace Feeds.API.Events
{
    public class ResourceEvent
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("lastCrawled")]
        public DateTimeOffset LastCrawled { get; set; }
        [JsonPropertyName("lastStatusCode")]
        public int LastStatusCode { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("event")]
        public string Event { get; set; }
    }
}
