using Resource.Actor.Interface.Models;
using System;
using System.Text.Json.Serialization;

namespace Resource.Actor.Events
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
        public ResourceType Type { get; set; }
        [JsonPropertyName("event")]
        public string Event { get; set; }
    }
}
