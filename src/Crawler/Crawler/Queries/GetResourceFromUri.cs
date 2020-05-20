using System;
using System.Net.Http;
using System.Net.Mime;
using System.Threading.Tasks;
using Crawler.Command;
using Crawler.Models;
using Resource.Models;
using Standard.Extensions;
using Standard.Queries;

namespace Crawler.Queries
{
    internal class GetResourceFromUri : IQuery<Uri, IResource>
    {
        private readonly HttpClient client;

        public GetResourceFromUri(HttpClient client)
        {
            this.client = client;
        }

        public async Task<IResource> ExecuteAsync(Uri model)
        {
            var response = await client.GetAsync(model);

            return await MakeResourceAsync(response);
        }

        private async Task<Crawler.Models.Resource> MakeResourceAsync(HttpResponseMessage response)
        {
            var resourceId = response.RequestMessage.RequestUri.ToGuid().ToString();

            var resource = new Crawler.Models.Resource(resourceId)
            {
                Self = response.RequestMessage.RequestUri,
                IsActive = response.IsSuccessStatusCode,
                StatusCode = (int)response.StatusCode
            };

            await LoadResourceDetails(response, resource);

            return resource;

        }

        private static async Task LoadResourceDetails(HttpResponseMessage response, Crawler.Models.Resource resource)
        {
            var content = await response.Content.ReadAsStringAsync();

            switch (response.Content.Headers.ContentType.MediaType)
            {
                case MediaTypeNames.Text.Html:
                {
                    var loadPageDetails = new LoadPageDetails(content);
                    await loadPageDetails.ApplyAsync(resource);
                }
                    break;
                case "application/rss+xml":
                case "application/xml":
                case MediaTypeNames.Text.Xml:
                {
                    var loadFeedDetails = new LoadFeedDetails(content);
                    await loadFeedDetails.ApplyAsync(resource);
                }
                    break;
            }
        }
    }
}