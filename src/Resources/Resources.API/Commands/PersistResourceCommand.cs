using System.Collections.Generic;
using Resources.API.Models;

namespace Resources.API.Commands
{
    class PersistResourceCommand : PersistCommand<List<Resource>>
    {
        const string STORENAME = "resources-state-store";

        public PersistResourceCommand(List<Resource> content,string key) : base(content, STORENAME, key)
        {
        }
    }
}