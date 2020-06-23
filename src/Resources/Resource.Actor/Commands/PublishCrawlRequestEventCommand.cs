using Resource.Actor.Events;

namespace Resource.Actor.Commands
{
    class PublishCrawlRequestEventCommand : PublishEventCommand<CrawlRequestEvent>
    {
        public PublishCrawlRequestEventCommand(CrawlRequestEvent content) : base(content, "crawl")
        {

        }
    }
}