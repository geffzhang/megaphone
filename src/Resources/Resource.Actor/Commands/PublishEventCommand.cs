using System.Threading.Tasks;
using Standard.Commands;
using Dapr.Client;

namespace Resource.Actor.Commands
{

    class PublishEventCommand<TEvent> : ICommand<DaprClient>
    {
        private readonly TEvent content;
        private readonly string topic;

        public PublishEventCommand(TEvent content, string topic)
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