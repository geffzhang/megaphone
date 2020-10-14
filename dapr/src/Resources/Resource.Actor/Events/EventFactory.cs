using Standard.Events;
using System;
using System.Collections.Generic;

namespace Resource.Actor.Events
{
    internal class EventFactory
    {
        internal static Event MakeCrawlRequestEvent(string url) => EventBuilder.NewEvent(Events.Crawler.Request)
                                                                               .WithParameter("url", url)
                                                                               .Make();
        internal static Event MakeResourceUpdateEvent(Models.Resource r)
        {
            return EventBuilder
                  .NewEvent(Events.Resource.Update)
                  .WithMetadata("updated", DateTimeOffset.UtcNow.ToString())
                  .WithMetadata("published", r.Published.ToString())
                  .WithMetadata("status", r.StatusCode.ToString())
                  .WithData("resource", "id", r.Id)
                  .WithData("resource", "display", r.Display)
                  .WithData("resource", "url", r.Self.ToString())
                  .WithData("resource", "type", r.Type)
                  .Make();
        }
    }
}
