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
        [JsonPropertyName("parameters")]
        public Dictionary<string, string> Parameters { get; set; } = new Dictionary<string, string>();
        [JsonPropertyName("metadata")]
        public Dictionary<string, string> Metadata { get; set; } = new Dictionary<string, string>();
        [JsonPropertyName("data")]
        public Dictionary<string, object> Data { get; set; } = new Dictionary<string, object>();
    }
}