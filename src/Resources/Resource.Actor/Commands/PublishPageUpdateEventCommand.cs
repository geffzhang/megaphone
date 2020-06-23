using Resource.Actor.Events;

namespace Resource.Actor.Commands
{

    class PublishPageUpdateEventCommand : PublishEventCommand<ResourceEvent>
    {
        public PublishPageUpdateEventCommand(ResourceEvent content) : base(content, "resource-updates")
        {

        }
    } 
}