using System.Threading.Tasks;
using HtmlAgilityPack;
using Standard.Commands;

namespace Crawler.Command
{
    internal class LoadPageDetails : ICommand<Crawler.Models.Resource>
    {
        private readonly string content;

        public LoadPageDetails(string content)
        {
            this.content = content;
        }

        public async Task ApplyAsync(Crawler.Models.Resource model)
        {
            model.Type = ResourceType.Page;

            var document = new HtmlDocument();
            document.LoadHtml(content);
            var title = document.DocumentNode.SelectSingleNode("//html/head/title");
            model.Display = title.InnerText;
        }
    }
}