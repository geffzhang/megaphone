using Standard.Events;
using System;

namespace Megaphone.API.Events
{
    internal class EventFactory
    {
        internal static Event MakeAddFeedEvent(Uri uri) => EventBuilder.NewEvent(Events.Feed.Add).WithParameter("url", uri.ToString()).Make();
        internal static Event MakeDeleteFeedEvent(string id) => EventBuilder.NewEvent(Events.Feed.Delete).WithParameter("id", id).Make();
    }
}
