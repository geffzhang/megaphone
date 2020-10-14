using System.Threading.Tasks;
using Standard.Commands;
using Standard.Services;
using Feeds.API.Services;
using System.Collections.Generic;
using Feeds.API.Models;
using Feeds.API.Queries;

namespace Feeds.API.Commands
{
    internal class UpsertResourceListCommand : ICommand<IPartionedStorageService<StorageEntry<List<Resource>>>>
    {
        readonly Resource resource;

        public UpsertResourceListCommand(Resource resource)
        {
            this.resource = resource;
        }

        public async Task ApplyAsync(IPartionedStorageService<StorageEntry<List<Resource>>> model)
        {
            var q = new GetResourceListQuery(resource.Published);
            var entry = await q.ExecuteAsync(model);

            if (!entry.HasValue)
            {
                entry.Value = new List<Resource> { resource };
            }
            else
            {
                var i = entry.Value.Find(i => i.Id == resource.Id);
                if (IsNotDefault(i))
                {
                    i.Display = resource.Display;
                    i.IsActive = resource.IsActive;
                    i.Updated = resource.Updated;
                    i.Published = resource.Published;
                }
                else
                {
                    entry.Value.Add(resource);
                }
            }

            var c = new PersistResourceListCommand(resource.Published, entry);
            await c.ApplyAsync(model);
        }

        static bool IsNotDefault(Resource r)
        {
            return r != null && !string.IsNullOrEmpty(r.Id);
        }
    }
}