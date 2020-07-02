using System.Linq;

namespace Megaphone.API.Models.Representations
{
    public static class RepresentationFactory
    {
        public static FeedListRepresentation MakeFeedListRepresentation(FeedListView view)
        {
            var r = new FeedListRepresentation
            {
                Updated = view.Updated
            };

            r.feeds.AddRange(view.Feeds.Select(f => MakeFeedRepresentation(f)));
            return r;
        }

        public static FeedRepresentation MakeFeedRepresentation(FeedView view)
        {
            var r = new FeedRepresentation(view.Id)
            {
                Display = view.Display,
                Url = view.Url
            };
            return r;
        }
    }
}