using System;
using System.Net.Http;
using System.Threading.Tasks;
using Standard.Commands;
using System.Text.Json;
using System.Text;

namespace Crawler.API.Commands
{
    internal class InvokePutMethodCommand : ICommand<HttpClient>
    {
        private readonly object content;
        private readonly string service;
        private readonly string path;

        string port;

        public InvokePutMethodCommand(object content, string service, string path)
        {
            port = Environment.GetEnvironmentVariable("DAPR_HTTP_PORT");
            this.content = content;
            this.service = service;
            this.path = path;
        }

        public async Task ApplyAsync(HttpClient model)
        {
            var putResult = await model.PutAsync($"http://localhost:{port}/v1.0/invoke/{service}/method/{path}", new StringContent(JsonSerializer.Serialize(content), Encoding.UTF8, "application/json"));
            if (!putResult.IsSuccessStatusCode)
                throw new Exception("Failed");
        }
    }
}