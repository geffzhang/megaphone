using System;
using System.Text.Json.Serialization;

namespace Crawler.API.Commands
{
    public class CrawlRequestEvent
    {
        [JsonPropertyName("url")]
        public string Url {get;set;}
        public bool HasValues => !string.IsNullOrEmpty(Display) || !string.IsNullOrEmpty(Description);
        [JsonPropertyName("published")]
        public DateTime Published { get; set; }
        [JsonPropertyName("display")]
        public string Display { get; set; } = String.Empty;
        [JsonPropertyName("description")]
        public string Description { get; set; } = String.Empty;
    }
}