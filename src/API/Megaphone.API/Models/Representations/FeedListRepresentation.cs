using Megaphone.API.Models.Representations.Links;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Megaphone.API.Models.Representations
{
    public class FeedListRepresentation : Representation
    {        
        public FeedListRepresentation()
        {
            base.AddLinks(Link.Make(Relations.Self, "api/feeds"));
        }

        [JsonPropertyName("feeds")]
        public List<FeedRepresentation> feeds { get; set; } = new List<FeedRepresentation>();

        [JsonPropertyName("updated")]
        public DateTimeOffset Updated { get; internal set; }
    }
}