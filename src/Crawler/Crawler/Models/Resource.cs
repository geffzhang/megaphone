using System;

namespace Crawler.Models
{
    public class Resource
    {
        public Resource(string id)
        {
            Id = id;
        }

        public string Id { get; }
        public string Display { get; set; }
        public int StatusCode { get; set; }
        public DateTimeOffset Created { get; set; } = DateTimeOffset.UtcNow;
        public bool IsActive { get ;set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public Uri Self { get; set; }
        public DateTimeOffset Published { get; set; }
        public string Cache { get; set; }
    }
}