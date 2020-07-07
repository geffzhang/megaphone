using System.Text.Json.Serialization;

namespace Feeds.API.Models.Views
{

    public class ResourceView
    {
        [JsonPropertyName("display")]
        public string Display { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}
