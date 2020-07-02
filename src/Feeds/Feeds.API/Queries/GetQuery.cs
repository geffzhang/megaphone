using System.Threading.Tasks;
using Standard.Queries;
using Dapr.Client;

namespace Feeds.API.Queries
{
    class GetQuery<TContent> : IQuery<DaprClient, TContent> where TContent : new()
    {
        private readonly string storeName;
        private readonly string storeKey;

        public GetQuery(string storeName, string storeKey)
        {
            this.storeName = storeName;
            this.storeKey = storeKey;
        }
        public async Task<TContent> ExecuteAsync(DaprClient model)
        {
                var state = await model.GetStateEntryAsync<TContent>(storeName, storeKey);
                return state.Value ??= new TContent();
        }
    }
}