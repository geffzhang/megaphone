using Standard.Events;
using System;
using System.Text.Json.Serialization;

namespace Crawler.API.Commands
{
    internal class EventFactory
    {
        internal static Event MakeCrawlRequestEvent(string url) => EventBuilder.NewEvent(Events.Crawler.Request)
                                                                               .WithParameter("url", url)
                                                                               .Make();
        internal static Event MakeCrawlRequestEvent(Models.Resource r)
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