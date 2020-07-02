namespace Megaphone.API.Models.Representations.Links
{
    public class FirstLink : Link
    {
        public const string Relation = "first";

        public FirstLink(string href, string title = null)
            : base(Relation, href, title)
        {
        }
    }
}