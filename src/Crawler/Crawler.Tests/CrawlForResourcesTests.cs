using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crawler.Models;
using Resource.Models;
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
            ResourceCrawler crawler = new WebResourceCrawler();
        }

        [Fact]
        public async Task WebCrawlerCanGetResource()
        {
            ResourceCrawler crawler = new WebResourceCrawler();

            var uri = "https://channel9.msdn.com/Shows/Azure-Friday/feed".ToUri();
            var resource = new Crawler.Models.Resource(uri.ToGuid().ToString())
            {
                Self = uri,
                Description = string.Empty
            };

            var resources = await crawler.GetChildResourcesAsync(resource).ConfigureAwait(false);

            Assert.IsAssignableFrom<IEnumerable<IResource>>(resources);
            Assert.True(resources.Any());
        }
    }
}