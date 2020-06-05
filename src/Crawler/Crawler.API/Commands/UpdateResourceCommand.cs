using System.Net.Http;
using System.Threading.Tasks;
using Standard.Commands;
using Crawler.Models;
using Crawler.API.Models;

namespace Crawler.API.Commands
{
    internal class UpdateResourceCommand : ICommand<HttpClient>
    {
        private readonly Resource resource;

        public UpdateResourceCommand(Resource resource)
        {
            this.resource = resource;
        }

        public async Task ApplyAsync(HttpClient model)
        {
            var c = new InvokePutMethodCommand(new ResourceRepresentation
            {
                Created = resource.Created,
                Description = resource.Description,
                Display = resource.Display,
                Id = resource.Id,
                IsActive = resource.IsActive,            
                Published = resource.Published,
                Self = resource.Self,
                StatusCode = resource.StatusCode,
                Type = resource.Type
            }, "resources-service", $"api/resources/{resource.Id}");
            await c.ApplyAsync(model);
        }
    }
}