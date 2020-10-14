using System.Text.Json.Serialization;

namespace Resource.Actor.Models
{
    class ResourceActorState
    {
        [JsonPropertyName("resource")]
        public Resource Resource { get; set; }
        [JsonPropertyName("crawlCount")]
        public int CrawlCount { get; internal set; } = 0;
        [JsonPropertyName("crawlStrategy")]
        public CrawlStrategy CrawlStrategy { get; internal set; } = CrawlStrategy.Hourly;
        [JsonPropertyName("isCrawlReminderActive")]
        public bool IsCrawlReminderActive { get; internal set; } = false;
    }
}
