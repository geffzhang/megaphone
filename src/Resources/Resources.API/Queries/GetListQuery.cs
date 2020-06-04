using System.Collections.Generic;
using Resources.API.Models;

namespace Resources.API.Queries
{
    class GetListQuery : GetQuery<List<Resource>>
    {
        const string STORENAME = "resources-state-store";

        public GetListQuery(string key) : base(STORENAME, key)
        {
        }
    }
}