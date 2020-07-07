using System.Collections.Generic;
using System.Threading.Tasks;
using Feeds.API.Models;
using Feeds.API.Services;
using Standard.Commands;
using Standard.Services;

namespace Feeds.API.Commands
{
    class PersistFeedListCommand : ICommand<IPartionedStorageService<StorageEntry<List<Feed>>>>
    {
        readonly StorageEntry<List<Feed>> entry;

        public PersistFeedListCommand(StorageEntry<List<Feed>> entry)
        {
            this.entry = entry;
        }

        public async Task ApplyAsync(IPartionedStorageService<StorageEntry<List<Feed>>> model)
        {
           await model.SetAsync("feed", "list.json", entry);
        }
    }
}