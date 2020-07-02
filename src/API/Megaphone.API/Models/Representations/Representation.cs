using Megaphone.API.Models.Representations.Links;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
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

        public void AddLink(string relation,string href)
        {
            links.Add(Link.Make(relation,href));
        }
        public void AddLink(string relation, string href, HttpMethod method)
        {
            links.Add(Link.Make(relation, href, method));
        }
    }
}