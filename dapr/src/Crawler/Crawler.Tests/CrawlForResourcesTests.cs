using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crawler.Models;
using Standard.Extensions;
using Xunit;
using Xunit.Abstractions;

namespace Crawler.XUnitTest
{
    public class CrawlForResourcesTests
    {
        private readonly ITestOutputHelper testOutputHelper;

        public CrawlForResourcesTests(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void CreateWebCrawler()
        {
            _ = new WebResourceCrawler();
        }       

        [Fact]
        public async Task WebCrawlerCanGetChildResources()
        {
            ResourceCrawler crawler = new WebResourceCrawler();

            var uri = "https://channel9.msdn.com/Shows/Azure-Friday/feed".ToUri();
         
            var resource = await crawler.GetResourceAsync(uri).ConfigureAwait(false);

            Assert.True(resource.Resources.Any());
        }
    }
}