using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Feeds.API.Models
{
    public class FeedListView
    {
        [JsonPropertyName("updated")]
        public DateTimeOffset Updated { get; set; } = DateTimeOffset.UtcNow;

        [JsonPropertyName("feeds")]
        public List<FeedView> Feeds { get; set; } = new List<FeedView>();
    }
}
