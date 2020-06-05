using System;
using System.Text.Json.Serialization;

namespace List.API.Models
{
    public class Item
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; } = String.Empty;

        [JsonPropertyName("added")]
        public DateTimeOffset Added { get; set; } = DateTimeOffset.UtcNow;

        [JsonPropertyName("lastCraweled")]
        public DateTimeOffset LastCrawled { get; set; } = DateTimeOffset.MinValue;

        [JsonPropertyName("lastHttpStatus")]
        public int? LastHttpStatus { get; set; } = null;
    }
}
