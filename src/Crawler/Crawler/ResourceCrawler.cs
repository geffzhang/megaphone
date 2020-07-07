using System;
using System.Threading.Tasks;
using Crawler.Models;

namespace Crawler
{
    public abstract class ResourceCrawler
    {
        public abstract Task<Resource> GetResourceAsync(Uri uri);
    }
}