namespace Megaphone.API.Models.Representations.Links
{
    public class CollectionLink : Link
    {
        public const string Relation = "collection";

        public CollectionLink(string href, string title = null)
            : base(Relation, href, title)
        {
        }
    }
}