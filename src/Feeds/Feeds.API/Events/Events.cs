using System;

namespace Feeds.API.Events
{
    public static class Events
    {
        public static class Feed
        {
            public static readonly string Add = "add-feed";
            public static readonly string Delete = "delete-feed";
        }

        public static class Crawler
        {
            public static readonly string Request = "request-crawl";
        }

        public static class Resource
        {
            public static readonly string Update = "update-resource";
        }
    }
}
