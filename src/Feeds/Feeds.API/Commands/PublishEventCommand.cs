using System;
using System.Net.Http;
using System.Threading.Tasks;
using Standard.Commands;
using System.Text.Json;
using System.Text;
using Dapr.Client;

namespace Feeds.API.Commands
{
    class PublishEventCommand : ICommand<DaprClient>
    {
        private readonly object content;
        private readonly string topic;

        public PublishEventCommand(object content, string topic)
        {
            this.content = content;
            this.topic = topic;
        }

        public async Task ApplyAsync(DaprClient model)
        {
            await model.PublishEventAsync(topic, content);
        }
    }
}