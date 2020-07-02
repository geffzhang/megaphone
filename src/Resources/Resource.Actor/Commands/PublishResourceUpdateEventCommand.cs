using Standard.Events;

namespace Resource.Actor.Commands
{

    class PublishResourceUpdateEventCommand : PublishEventCommand<Event>
    {
        public PublishResourceUpdateEventCommand(Event content) : base(content, "resource-updates")
        {

        }
    } 
}