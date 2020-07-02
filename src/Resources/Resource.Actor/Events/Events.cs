namespace Resource.Actor.Events
{
    public static class Events
    {
        public static class Resource
        {
            public static readonly string Update = "update-resource";
        }

        public static class Crawler
        {
            public static readonly string Request = "request-crawl";
        }
    }
}
