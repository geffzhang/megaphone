using System.Threading.Tasks;
using Crawler.Models;
using HtmlAgilityPack;
using Standard.Commands;

namespace Crawler.Command
{
    internal class LoadFeedDetails : ICommand<Resource>
    {
        private readonly string content;

        public LoadFeedDetails(string content)
        {
            this.content = content;
        }

        public async Task ApplyAsync(Resource model)
        {
            model.Type = ResourceType.Feed;

            var document = new HtmlDocument();
            document.LoadHtml(content);

            SetTitle(model, document);
            SetDescription(model, document);

            await Task.CompletedTask;
        }
        private static void SetTitle(Resource model, HtmlDocument document)
        {
            var title = document.DocumentNode.SelectSingleNode("//rss/channel/title");
            model.Display = title.InnerText;
        }
        private static void SetDescription(Resource model, HtmlDocument document)
        {
            var description = document.DocumentNode.SelectSingleNode("//rss/channel/description");
            model.Description = description.InnerText;
        }
    }
}