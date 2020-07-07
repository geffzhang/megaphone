using System.Collections.Generic;
using System.Threading.Tasks;
using Feeds.API.Models;
using Feeds.API.Services;
using Standard.Queries;
using Standard.Services;

namespace Feeds.API.Queries
{
    class GetFeedListQuery : IQuery<IPartionedStorageService<StorageEntry<List<Feed>>>, StorageEntry<List<Feed>>>
    {
        public async Task<StorageEntry<List<Feed>>> ExecuteAsync(IPartionedStorageService<StorageEntry<List<Feed>>> model)
        {
            var entry = await model.GetAsync("feed", "list.json");
            return entry;
        }
    }
}