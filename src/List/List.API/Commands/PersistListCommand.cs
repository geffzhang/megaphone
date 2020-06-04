using System.Collections.Generic;
using List.API.Models;

namespace List.API.Commands
{
    class PersistListCommand : PersistCommand<List<Item>>
    {
        const string STORENAME = "list-state-store";
        const string STOREKEY = "list";

        public PersistListCommand(List<Item> content) : base(content, STORENAME, STOREKEY)
        {
        }
    }
}