using System.Threading.Tasks;
using Standard.Commands;
using Dapr.Client;

namespace List.API.Commands
{
    class PersistCommand<TContent> : ICommand<DaprClient>
    {
        private readonly TContent content;
        private readonly string storeName;
        private readonly string storeKey;
       
        public PersistCommand(TContent content, string storeName, string storeKey)
        {
            this.content = content;
            this.storeName = storeName;
            this.storeKey = storeKey;
        }

        public async Task ApplyAsync(DaprClient model)
        {
            var state = await model.GetStateEntryAsync<TContent>(storeName, storeKey);
            state.Value = content;
            await state.SaveAsync();
        }
    }
}