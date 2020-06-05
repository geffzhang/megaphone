using System;

namespace Crawler.Models
{
    [Serializable]
    public class Resource
    {
        public Resource(string id)
        {
            Id = id;
        }

        public string Id { get; }
        public string Display { get; internal set; }
        public int StatusCode { get; internal set; }
        public DateTimeOffset Created { get; internal set; } = DateTimeOffset.UtcNow;
        public bool IsActive { get; internal set; }
        public ResourceType Type { get; internal set; }
        public string Description { get; set; }
        public Uri Self { get; set; }
        public DateTime Published { get; set; }
    }
}