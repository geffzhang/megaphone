using System.Collections.Generic;
using Crawler.API.Models;

namespace Crawler.API.Queries
{
    class GetWatchListQuery : GetQuery<List<Item>>
    {
        const string STORENAME = "crawler-state-store";
        const string STOREKEY = "crawler-watchlist";
        public GetWatchListQuery() : base(STORENAME, STOREKEY)
        {
        }
    }
}