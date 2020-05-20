using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Resource.Models;

namespace Crawler
{
    public abstract class ResourceCrawler
    {
        public abstract Task<IResource> GetResourceAsync(Uri uri);

        public abstract Task<IEnumerable<IResource>> GetChildResourcesAsync(IResource resource);
    }
}