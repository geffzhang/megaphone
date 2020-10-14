using System;
using System.Net.Http;
using System.Threading.Tasks;
using Standard.Commands;
using System.Text.Json;
using System.Text;
using System.Net.Http.Headers;

namespace Crawler.API.Commands
{
    class PublishEventCommand : ICommand<HttpClient>{
        private readonly object content;
        private readonly string topic;
        private readonly string traceparent;
        private readonly string port;

        public PublishEventCommand(object content, string topic, string traceparent)
        {
            port = Environment.GetEnvironmentVariable("DAPR_HTTP_PORT");
            this.content = content;
            this.topic = topic;
            this.traceparent = traceparent;
        }

        public async Task ApplyAsync(HttpClient model)
        {
            using var request = new HttpRequestMessage()
            {
                RequestUri = new Uri($"http://localhost:{port}/v1.0/publish/{topic}"),
                Method = HttpMethod.Post,
                Content = new StringContent(JsonSerializer.Serialize(content), Encoding.UTF8, "application/json")
            };
            request.Headers.Add("traceparent", this.traceparent);
            
            var postResult = await model.SendAsync(request);
            if (!postResult.IsSuccessStatusCode)
                throw new Exception("Failed to publish");
        }
    } 
}