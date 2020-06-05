using System.Collections.Generic;
using Resources.API.Models;

namespace Resources.API.Queries
{
    class GetResourceQuery : GetQuery<Resource>
    {
        const string STORENAME = "resources-state-store";

        public GetResourceQuery(string key) : base(STORENAME, key)
        {
        }
    }
}