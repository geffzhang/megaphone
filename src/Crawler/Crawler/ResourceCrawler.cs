using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Crawler.Models;

namespace Crawler
{
    public abstract class ResourceCrawler
    {
        public abstract Task<Resource> GetResourceAsync(Uri uri);

        public abstract Task<IEnumerable<Resource>> GetChildResourcesAsync(Resource resource);
    }
}