namespace Megaphone.API.Models.Representations.Links
{
    public class DeleteLink : Link
    {
        public const string Relation = "delete";

        public DeleteLink(string href, string title = null)
            : base(Relation, href, title)
        {
        }
    }
}