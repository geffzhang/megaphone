using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace Standard.Events
{
    public class Event
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("created")]
        public DateTimeOffset Created { get; set; } = DateTimeOffset.UtcNow;
        [JsonPropertyName("params")]
        public Dictionary<string, string> Parameters { get; set; } = new Dictionary<string, string>();
    }
}