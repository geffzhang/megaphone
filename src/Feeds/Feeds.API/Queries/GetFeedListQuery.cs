using System.Collections.Generic;
using Feeds.API.Models;

namespace Feeds.API.Queries
{
    class GetFeedListQuery : GetQuery<List<Feed>>
    {
        const string STORENAME = "feed-state-store";
        const string STOREKEY = "feed-list";

        public GetFeedListQuery() : base(STORENAME, STOREKEY)
        {
        }
    }
}