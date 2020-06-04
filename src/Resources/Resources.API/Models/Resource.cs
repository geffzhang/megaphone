using System;
using System.Text.Json.Serialization;

namespace Resources.API.Models
{
    public class Resource
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("added")]
        public DateTimeOffset Added { get; set; } = DateTimeOffset.UtcNow;

        [JsonPropertyName("lastCrawled")]
        public DateTimeOffset LastCrawled { get; set; } = DateTimeOffset.UtcNow;

        [JsonPropertyName("lastHttpStatus")]
        public string LastHttpStatus { get; set; } = string.Empty;
    }
}
