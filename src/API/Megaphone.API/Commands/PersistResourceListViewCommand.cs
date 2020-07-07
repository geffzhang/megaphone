using Megaphone.API.Models.Views;
using Standard.Commands;
using Standard.Services;
using System;
using System.Threading.Tasks;

namespace Megaphone.API.Controllers
{
    internal class PersistResourceListViewCommand : ICommand<IPartionedStorageService<ResourceListView>>
    {
        const string CONTENT_KEY = "resources.json";

        readonly ResourceListView view;
        readonly string partitionKey;

        public PersistResourceListViewCommand(DateTime date, ResourceListView view)
        {
            partitionKey = $"{date.Year}/{date.Month}/{date.Day}";
            this.view = view;
        }

        public async Task ApplyAsync(IPartionedStorageService<ResourceListView> model)
        {
            await model.SetAsync(partitionKey, CONTENT_KEY, view);
        }
    }
}
