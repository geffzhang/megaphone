using System.Collections.Generic;
using Crawler.API.Models;

namespace Crawler.API.Commands
{
    class PersistWatchListCommand : PersistCommand<List<Item>>
    {
        const string STORENAME = "crawler-state-store";
        const string STORELISTKEY = "crawler-watchlist";

        public PersistWatchListCommand(List<Item> content) : base(content, STORENAME, STORELISTKEY)
        {
        }
    }
}