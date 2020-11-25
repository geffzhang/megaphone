using Crawler.Models;
using Standard.Events;

namespace FunctionApp.Crawler
{
    internal class EventFactory
    {
        internal static Event MakeCrawlRequestEvent(string url) => EventBuilder.NewEvent(Events.Crawler.Request)
                                                                               .WithParameter("url", url)
                                                                               .Make();
        internal static Event MakeCrawlRequestEvent(Resource r)
        {
            return EventBuilder
                  .NewEvent(Events.Crawler.Request)
                  .WithParameter("url", r.Self.OriginalString)
                  .WithData("resource", "display", r.Display)
                  .WithData("resource", "description", r.Description)
                  .WithData("resource", "published", r.Published.ToString())
                  .Make();
        }
    }
}
