using Dapr.Client.Http;
using Megaphone.API.Models.Representations.Links;
using System.Net.Http;
using System.Text.Json.Serialization;

namespace Megaphone.API.Models.Representations
{
    public class FeedRepresentation : Representation
    {
        public FeedRepresentation(string Id)
        {
            base.AddLink(Relations.Self, $"api/feeds/{Id}");
            base.AddLink(Relations.Delete, $"api/feeds/{Id}", HttpMethod.Delete);
        }
        [JsonPropertyName("display")]
        public string Display { get; internal set; }
        [JsonPropertyName("url")]
        public string Url { get; internal set; }
    }
}