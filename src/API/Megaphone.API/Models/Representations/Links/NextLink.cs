namespace Megaphone.API.Models.Representations.Links
{
    public class NextLink : Link
    {
        public const string Relation = "next";

        public NextLink(string href, string title = null)
            : base(Relation, href, title)
        {
        }
    }
}