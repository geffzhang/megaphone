using System.Collections.Generic;
using Feeds.API.Models;

namespace Feeds.API.Commands
{
    class PersistFeedListCommand : PersistCommand<List<Feed>>
    {
        const string STORENAME = "feed-state-store";
        const string STOREKEY = "feed-list";

        public PersistFeedListCommand(List<Feed> content) : base(content, STORENAME, STOREKEY)
        {
        }
    }
}