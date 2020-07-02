using Megaphone.API.Models.Representations.Links;
using System.Text.Json.Serialization;

namespace Megaphone.API.Models.Representations
{
    public class FeedRepresentation : Representation
    {
        public FeedRepresentation(string Id)
        {
            base.AddLink(new DeleteLink($"api/feeds/{Id}"));
            base.AddLink(new SelfLink($"api/feeds/{Id}"));
        }
        [JsonPropertyName("display")]
        public string Display { get; internal set; }
        [JsonPropertyName("url")]
        public string Url { get; internal set; }
    }
}