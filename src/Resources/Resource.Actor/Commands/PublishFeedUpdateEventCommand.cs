using Resource.Actor.Events;

namespace Resource.Actor.Commands
{
    class PublishFeedUpdateEventCommand : PublishEventCommand<ResourceEvent>
    {
        public PublishFeedUpdateEventCommand(ResourceEvent content) : base(content, "resource-feed-updates")
        {

        }
    }
}