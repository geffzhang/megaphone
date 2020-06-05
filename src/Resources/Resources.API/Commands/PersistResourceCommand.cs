using System.Collections.Generic;
using Resources.API.Models;

namespace Resources.API.Commands
{
    class PersistResourceCommand : PersistCommand<Resource>
    {
        const string STORENAME = "resources-state-store";

        public PersistResourceCommand(Resource content,string key) : base(content, STORENAME, key)
        {
        }
    }
}