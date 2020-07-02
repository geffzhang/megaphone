namespace Megaphone.API.Models.Representations.Links
{
    public class RelatedLink : Link
    {
        public const string Relation = "related";

        public RelatedLink(string href, string title = null)
            : base(Relation, href, title)
        {
        }
    }
}