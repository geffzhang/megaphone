namespace Megaphone.API.Models.Representations.Links
{
    public class PreviousLink : Link
    {
        public const string Relation = "prev";

        public PreviousLink(string href, string title = null)
            : base(Relation, href, title)
        {
        }
    }
}