using System.Text.Json.Serialization;

namespace Resources.API.Events
{
    public class ResourceEvent
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
