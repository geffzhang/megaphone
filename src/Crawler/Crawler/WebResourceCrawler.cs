using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Crawler.Models;
using Crawler.Queries;
using Microsoft.SyndicationFeed;
using Microsoft.SyndicationFeed.Atom;
using Microsoft.SyndicationFeed.Rss;
using Standard.Extensions;

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

        public override async Task<IEnumerable<Resource>> GetChildResourcesAsync(Resource resource)
        {
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(resource.Cache)) { Position = 0 };

            List<Resource> resources = new List<Resource>();

            //if (model.FeedType == "rss")
            //{
            resources = await TryMaterializeResourcesFromRssFeedAsync(stream);
            //}
            //else
            //{
            //    resources = await TryMaterializeResourcesFromAtomFeedAsync(stream);
            //}          

            return resources;
        }

        private async Task<List<Resource>> TryMaterializeResourcesFromRssFeedAsync(MemoryStream stream)
        {
            using var xmlReader = XmlReader.Create(stream, new XmlReaderSettings { Async = true });

            var feedReader = new RssFeedReader(xmlReader);

            return await ToResources(feedReader);
        }

        private async Task<List<Resource>> TryMaterializeResourcesFromAtomFeedAsync(MemoryStream stream)
        {
            using var xmlReader = XmlReader.Create(stream, new XmlReaderSettings { Async = true });
            var feedReader = new AtomFeedReader(xmlReader);

            return await ToResources(feedReader);
        }

        private async Task<List<Resource>> ToResources(XmlFeedReader feedReader)
        {
            var resources = new List<Resource>();

            while (await feedReader.Read())
            {
                if (feedReader.ElementType != SyndicationElementType.Item) continue;

                var item = await feedReader.ReadContent();

                var uri = GetUri(item);

                if (uri == null) continue;

                var published = GetPublicationDate(item);
                if (!published.HasValue)
                    break;

                var description = GetDescription(item);

                var r = new Resource(uri.ToGuid().ToString())
                {
                    Published = published.Value.ToUniversalTime(),
                    Display = GetTitle(item),
                    Description = description,
                    Self = uri
                };

                resources.Add(r);
            }
            return resources;
        }

        private string GetDescription(ISyndicationContent content)
        {
            var d = content.Fields.FirstOrDefault(x => x.Name == "description");
            if (d?.Value != null)
                return d.Value;

            var c = content.Fields.FirstOrDefault(x => x.Name == "content");
            if (c?.Value != null)
                return c.Value;

            var e = content.Fields.FirstOrDefault(x => x.Name == "encoded");
            if (e?.Value != null)
                return e.Value;

            return string.Empty;
        }

        public static List<string> GetTags(ISyndicationContent content)
        {
            var rawCategories = content.Fields.Where(x => x.Name == "category").ToList();
            IEnumerable<string> categoriesAsElements = rawCategories
                .Select(x => x.Value)
                .Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();

            IEnumerable<string> categoriesAsTerms = rawCategories
                .Select(x => x.Attributes.FirstOrDefault(y => y.Name == "term")?.Value)
                .Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();

            var result = categoriesAsElements.Any() ? categoriesAsElements : categoriesAsTerms.Any() ? categoriesAsTerms : Enumerable.Empty<string>();

            return result.Distinct().ToList();
        }

        private DateTime? GetPublicationDate(ISyndicationContent content)
        {
            var pubDate = content.Fields.FirstOrDefault(x => x.Name == "pubDate" || x.Name == "published" || x.Name == "updated");

            var date = pubDate?.Value
                               .Replace("(PST)", "")
                               .Replace("(PDT)", "")
                               .Replace("GMT", "")
                               .Replace("+0000 (UTC)", "")
                               .Trim();

            if (DateTimeOffset.TryParse(date, out var pubDateParsed))
            {
                return pubDateParsed.UtcDateTime;
            }

            return null;
        }

        private Uri GetUri(ISyndicationContent content)
        {
            var link = content.Fields.FirstOrDefault(x => x.Name == "link");
            if (link != null)
            {
                var hrefAttribute = link.Attributes.SingleOrDefault(x => x.Name == "href");
                return hrefAttribute != null ? new Uri(hrefAttribute.Value.Trim())
                                             : new Uri(link.Value.Trim());
            }


            var guid = content.Fields.FirstOrDefault(x => x.Name == "link");
            if (!string.IsNullOrWhiteSpace(guid?.Value))
                if (guid != null) return new Uri(guid.Value);

            return null;
        }

        private string GetTitle(ISyndicationContent content)
        {
            var title = content.Fields.FirstOrDefault(x => x.Name == "title");
            if (title?.Value != null)
                return title.Value;

            return string.Empty;
        }
    }
}