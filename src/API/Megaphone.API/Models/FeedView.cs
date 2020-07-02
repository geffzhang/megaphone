using System.Text.Json.Serialization;

namespace Megaphone.API.Models
{
    public class FeedView
    {
        [JsonPropertyName("display")]
        public string Display { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}