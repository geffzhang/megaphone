using Megaphone.API.Models.Representations.Links;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Megaphone.API.Models.Representations
{
    public abstract class Representation
    {

        private readonly List<Link> links = new List<Link>();

        [JsonPropertyName("links")]
        public IEnumerable<Link> Links { get { return links; } }

        public void AddLink(Link link)
        {
            links.Add(link);
        }

        public void AddLinks(params Link[] links)
        {
            this.links.AddRange(links);
        }
    }
}