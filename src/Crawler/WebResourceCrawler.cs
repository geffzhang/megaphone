using System;
using System.Net.Http;
using System.Threading.Tasks;
using Crawler.Models;
using Crawler.Queries;

namespace Crawler
{
    public class WebResourceCrawler : ResourceCrawler
    {
        private static readonly HttpClient Client = new HttpClient();

        public override async Task<Resource> GetResourceAsync(Uri uri)
        {
            var query = new GetResourceFromUri(Client);
            return await query.ExecuteAsync(uri);
        }
    }
}