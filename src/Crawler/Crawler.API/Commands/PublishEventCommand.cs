using System;
using System.Net.Http;
using System.Threading.Tasks;
using Standard.Commands;
using System.Text.Json;
using System.Text;

namespace Crawler.API.Commands
{
    class PublishEventCommand : ICommand<HttpClient>{
        private readonly object content;
        private readonly string topic;
        string port;

        public PublishEventCommand(object content, string topic)
        {
            port = Environment.GetEnvironmentVariable("DAPR_HTTP_PORT");
            this.content = content;
            this.topic = topic;
        }

        public async Task ApplyAsync(HttpClient model)
        {
            var postResult = await model.PostAsync($"http://localhost:{port}/v1.0/publish/{topic}",new StringContent(JsonSerializer.Serialize(content),Encoding.UTF8,"application/json"));
            if (!postResult.IsSuccessStatusCode)
                throw new Exception("Failed to publish");
        }
    }
}