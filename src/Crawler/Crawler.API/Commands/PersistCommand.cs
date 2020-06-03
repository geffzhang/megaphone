using System;
using System.Net.Http;
using System.Threading.Tasks;
using Standard.Commands;
using System.Text.Json;
using System.Text;

namespace Crawler.API.Commands
{
    class PersistCommand<TContent> : ICommand<HttpClient>
    {
        private readonly TContent content;
        private readonly string storeName;
        private readonly string storeKey;
        string port;
        public PersistCommand(TContent content, string storeName, string storeKey)
        {
            port = Environment.GetEnvironmentVariable("DAPR_HTTP_PORT");
            this.content = content;
            this.storeName = storeName;
            this.storeKey = storeKey;
        }

        public async Task ApplyAsync(HttpClient model)
        {
            var postResult = await model.PostAsync($"http://localhost:{port}/v1.0/state/{storeName}",
             new StringContent(JsonSerializer.Serialize(new[] { new { key = storeKey, value = content } }), Encoding.UTF8, "application/json"));

            if (!postResult.IsSuccessStatusCode)
                throw new Exception("Failed to persist");
        }
    }
}