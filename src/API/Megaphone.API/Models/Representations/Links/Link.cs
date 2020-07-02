using System.Text.Json.Serialization;

namespace Megaphone.API.Models.Representations.Links
{
    public abstract class Link
    {
        [JsonPropertyName("rel")]
        public string Rel { get; private set; }
        [JsonPropertyName("href")]
        public string Href { get; private set; }

        public Link(string relation, string href, string title = null)
        {
            Rel = relation;
            Href = href;
        }
    }
}