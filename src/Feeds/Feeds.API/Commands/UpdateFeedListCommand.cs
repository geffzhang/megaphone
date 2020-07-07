using System.Threading.Tasks;
using Standard.Commands;
using Feeds.API.Models;
using Feeds.API.Queries;
using Standard.Services;
using Feeds.API.Services;
using System.Collections.Generic;

namespace Feeds.API.Commands
{
    internal class UpdateFeedListCommand : ICommand<IPartionedStorageService<StorageEntry<List<Feed>>>>
    {
        readonly Feed feed;

        public UpdateFeedListCommand(Feed feed)
        {
            this.feed = feed;
        }

        public async Task ApplyAsync(IPartionedStorageService<StorageEntry<List<Feed>>> model)
        {
            var q = new GetFeedListQuery();
            var entry = await q.ExecuteAsync(model);

            var i = entry.Value.Find(i => i.Id == feed.Id);
            if (IsNotDefault(i))
            {
                i.LastCrawled = feed.LastCrawled;
                i.LastHttpStatus = feed.LastHttpStatus;
                i.Display = feed.Display;

                var c = new PersistFeedListCommand(entry);
                await c.ApplyAsync(model);
            }
        }

        static bool IsNotDefault(Feed f)
        {
            return f != null && !string.IsNullOrEmpty(f.Id);
        }
    }
}