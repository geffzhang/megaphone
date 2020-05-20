using System.Threading.Tasks;
using Crawler.Models;
using HtmlAgilityPack;
using Standard.Commands;

namespace Crawler.Command
{
    internal class LoadFeedDetails : ICommand<Models.Resource>
    {
        private readonly string content;

        public LoadFeedDetails(string content)
        {
            this.content = content;
        }

        public async Task ApplyAsync(Models.Resource model)
        {
            model.Type = ResourceType.Feed;

            var document = new HtmlDocument();
            document.LoadHtml(content);

            SetTitle(model, document);
            SetDescription(model, document);

            await Task.CompletedTask;
        }
        private static void SetTitle(Models.Resource model, HtmlDocument document)
        {
            var title = document.DocumentNode.SelectSingleNode("//rss/channel/title");
            model.Display = title.InnerText;
        }
        private static void SetDescription(Models.Resource model, HtmlDocument document)
        {
            var description = document.DocumentNode.SelectSingleNode("//rss/channel/description");
            model.Description = description.InnerText;
        }
    }
}