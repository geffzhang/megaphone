using System;
using System.Text.Json.Serialization;

namespace Resources.API.Models
{
    public class ResourceRepresentation
    {
         [JsonPropertyName("id")]
        public string Id { get; set;}
        [JsonPropertyName("display")]
        public string Display { get; set; }
        [JsonPropertyName("statusCode")]
        public int StatusCode { get; set; }
        [JsonPropertyName("created")]
        public DateTimeOffset Created { get; set; } = DateTimeOffset.UtcNow;
        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }
        [JsonPropertyName("type")]
        public ResourceType Type { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("self")]
        public Uri Self { get; set; }
        [JsonPropertyName("published")]
        public DateTime Published { get; set; }
    }
}
