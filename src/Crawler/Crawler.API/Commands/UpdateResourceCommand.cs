using System.Net.Http;
using System.Threading.Tasks;
using Standard.Commands;
using Resource.Actor.Interface.Models;
using Resource.Actor.Interface;
using Dapr.Actors;
using Dapr.Actors.Client;

namespace Crawler.API.Commands
{
    internal class UpdateResourceCommand : ICommand<HttpClient>
    {
        private readonly Models.Resource resource;

        public UpdateResourceCommand(Models.Resource resource)
        {
            this.resource = resource;
        }

        public async Task ApplyAsync(HttpClient model)
        {
            var r = new ResourceRepresentation
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
            };

            var proxy = ActorProxy.Create<IResourceActor>(new ActorId(r.Id), "Resource");
            await proxy.UpdateAsync(r);
        }
    }
}