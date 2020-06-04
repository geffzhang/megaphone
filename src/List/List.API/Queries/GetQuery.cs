using System;
using System.Net.Http;
using System.Threading.Tasks;
using Standard.Queries;
using System.Text.Json;

namespace List.API.Queries
{
    class GetQuery<TContent> : IQuery<HttpClient, TContent> where TContent : new()
    {
        private readonly string storeName;
        private readonly string storeKey;
        string port;

        public GetQuery(string storeName, string storeKey)
        {
            port = Environment.GetEnvironmentVariable("DAPR_HTTP_PORT");
            this.storeName = storeName;
            this.storeKey = storeKey;
        }
        public async Task<TContent> ExecuteAsync(HttpClient model)
        {
            var response = await model.GetAsync($"http://localhost:{port}/v1.0/state/{storeName}/{storeKey}");
            var stringContent = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrEmpty(stringContent))
                return new TContent();

            var content = JsonSerializer.Deserialize<TContent>(stringContent);
            return content;
        }
    }
}