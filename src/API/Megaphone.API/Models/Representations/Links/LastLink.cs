namespace Megaphone.API.Models.Representations.Links
{
    public class LastLink : Link
    {
        public const string Relation = "last";

        public LastLink(string href, string title = null)
            : base(Relation, href, title)
        {
        }
    }
}