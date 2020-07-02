using Standard.Events;

namespace Resource.Actor.Commands
{
    class PublishCrawlRequestEventCommand : PublishEventCommand<Event>
    {
        public PublishCrawlRequestEventCommand(Event content) : base(content, "crawl")
        {

        }
    }
}