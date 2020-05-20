using System.Threading.Tasks;
using HtmlAgilityPack;
using Standard.Commands;

namespace Crawler.Command
{
    internal class LoadFeedDetails : ICommand<Crawler.Models.Resource>
    {
        private readonly string content;

        public LoadFeedDetails(string content)
        {
            this.content = content;
        }

        public async Task ApplyAsync(Crawler.Models.Resource model)
        {
            model.Type = ResourceType.Feed;

            var document = new HtmlDocument();
            document.LoadHtml(content);

            SetTitle(model, document);
            SetDescription(model, document);

        }
        private static void SetTitle(Crawler.Models.Resource model, HtmlDocument document)
        {
            var title = document.DocumentNode.SelectSingleNode("//rss/channel/title");
            model.Display = title.InnerText;
        }
        private static void SetDescription(Crawler.Models.Resource model, HtmlDocument document)
        {
            var description = document.DocumentNode.SelectSingleNode("//rss/channel/description");
            model.Description = description.InnerText;
        }
    }
}