namespace Megaphone.API.Models.Representations.Links
{
    public class AlternateLink : Link
    {
        public const string Relation = "alternate";

        public AlternateLink(string href, string title = null)
            : base(Relation, href, title)
        {
        }
    }
}