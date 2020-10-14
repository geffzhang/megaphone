using Standard.Events;

namespace Feeds.API.Events
{
    internal class EventFactory
    {
        internal static Event MakeCrawlRequestEvent(string url) => EventBuilder.NewEvent(Events.Crawler.Request).WithParameter("url", url).Make();
    }
}
