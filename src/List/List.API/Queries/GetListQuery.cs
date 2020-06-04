using System.Collections.Generic;
using List.API.Models;

namespace List.API.Queries
{
    class GetListQuery : GetQuery<List<Item>>
    {
        const string STORENAME = "list-state-store";
        const string STOREKEY = "list";

        public GetListQuery() : base(STORENAME, STOREKEY)
        {
        }
    }
}