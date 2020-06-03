using System;
using System.Text.Json.Serialization;

namespace Crawler.API.Models
{
    public class Item
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("added")]
        public DateTimeOffset Added { get; set; } = DateTimeOffset.UtcNow;

        [JsonPropertyName("lastCraweled")]
        public DateTimeOffset LastCrawled { get; set; } = DateTimeOffset.UtcNow;

        [JsonPropertyName("lastHttpStatus")]
        public string LastHttpStatus { get; set; } = string.Empty;
    }
}
