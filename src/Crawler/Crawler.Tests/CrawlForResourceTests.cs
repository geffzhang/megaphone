using System;
using System.Threading.Tasks;
using Crawler.Models;
using Standard.Extensions;
using Xunit;
using Xunit.Abstractions;

namespace Crawler.XUnitTest
{
    public class CrawlForResourceTests
    {
        private readonly ITestOutputHelper testOutputHelper;

        public CrawlForResourceTests(ITestOutputHelper testOutputHelper)
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
            var resource = await crawler.GetResourceAsync("https://www.google.com".ToUri()).ConfigureAwait(false);
            Assert.IsAssignableFrom<IResource>(resource);
        }

        [Fact]
        public async Task WebCrawlerGetResourceHasId()
        {
            ResourceCrawler crawler = new WebResourceCrawler();
            var resource = await crawler.GetResourceAsync("https://www.google.com".ToUri()).ConfigureAwait(false);
            Assert.True(!string.IsNullOrWhiteSpace(resource.Id));
            Assert.True(resource.Self.IsWellFormedOriginalString());

            testOutputHelper.WriteLine(resource.Id);
        }
 
        [Fact]
        public async Task WebCrawlerGetResourceHasPredictableId()
        {
            ResourceCrawler crawler = new WebResourceCrawler();
            var resource = await crawler.GetResourceAsync("https://www.google.com".ToUri()).ConfigureAwait(false);
            Assert.True(String.CompareOrdinal(resource.Id, "95555d86-7dd0-51a7-ab15-99805fb8a4e4")==0);
            
            testOutputHelper.WriteLine(resource.Id);
        }

        [Fact]
        public async Task WebCrawlerGetResourceHasCreatedDate()
        {
            ResourceCrawler crawler = new WebResourceCrawler();
            var resource = await crawler.GetResourceAsync("https://www.google.com".ToUri()).ConfigureAwait(false);
            Assert.True(resource.Created > DateTimeOffset.UtcNow.Subtract(TimeSpan.FromMinutes(1)));
        }
        
        [Fact]
        public async Task WebCrawlerGetResourceHasStatusCode202()
        {
            ResourceCrawler crawler = new WebResourceCrawler();
            var resource = await crawler.GetResourceAsync("https://www.google.com".ToUri()).ConfigureAwait(false);
            Assert.Equal(200, resource.StatusCode);
        } 

        [Fact]
        public async Task WebCrawlerGetResourceHasGuidTypeId()
        {
            ResourceCrawler crawler = new WebResourceCrawler();
            var resource = await crawler.GetResourceAsync("https://www.google.com".ToUri()).ConfigureAwait(false);
            Assert.True(Guid.TryParse(resource.Id, out Guid id));
        }

        [Fact]
        public async Task WebCrawlerGetResourceHasTitle()
        {
            ResourceCrawler crawler = new WebResourceCrawler();
            var resource = await crawler.GetResourceAsync("https://www.google.com".ToUri()).ConfigureAwait(false);
            Assert.True(String.CompareOrdinal(resource.Display, "Google") == 0);
        }
        
        [Fact]
        public async Task WebCrawlerGetResourceHasIsHtml()
        {
            ResourceCrawler crawler = new WebResourceCrawler();
            var resource = await crawler.GetResourceAsync("https://www.google.com".ToUri()).ConfigureAwait(false);
            Assert.True(resource.Type == ResourceType.Page);
        } 
        
        [Fact]
        public async Task WebCrawlerGetAzureBlogResourceAsPage()
        {
            ResourceCrawler crawler = new WebResourceCrawler();
            var resource = await crawler.GetResourceAsync("https://azure.microsoft.com/en-us/blog/".ToUri()).ConfigureAwait(false);
            Assert.True(String.CompareOrdinal(resource.Display, "Azure Blog and Updates | Microsoft Azure") == 0);
            Assert.True(resource.Type == ResourceType.Page);
        } 
        
        [Fact]
        public async Task WebCrawlerGetAzureBlogResourceAsFeed()
        {
            ResourceCrawler crawler = new WebResourceCrawler();
            var resource = await crawler.GetResourceAsync("https://azure.microsoft.com/en-us/blog/feed/".ToUri()).ConfigureAwait(false);
            Assert.True(String.CompareOrdinal(resource.Display, "Microsoft Azure Blog") == 0);
            Assert.True(resource.Type == ResourceType.Feed);
        } 
        
        [Fact]
        public async Task WebCrawlerGetAzureFridayResourceAsFeedWithTitleAndDescription()
        {
            ResourceCrawler crawler = new WebResourceCrawler();
            var resource = await crawler.GetResourceAsync("https://channel9.msdn.com/Shows/Azure-Friday/feed".ToUri()).ConfigureAwait(false);
            Assert.True(String.CompareOrdinal(resource.Display, "Azure Friday  - Channel 9") == 0);
            Assert.True(resource.Type == ResourceType.Feed);
            Assert.False(string.IsNullOrEmpty(resource.Description));
        }
    }
}