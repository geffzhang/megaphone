using System;

namespace Standard.Extensions
{
    public static class UriExtensions
    {
        public static Guid ToGuid(this Uri uri)
        {
            var guid = GuidUtility.Create(GuidUtility.UrlNamespace, uri.AbsoluteUri);
            return guid;
        }

        public static Uri ToUri(this string uri)
        {
            return new Uri(uri);
        }
    }
}