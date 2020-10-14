using Megaphone.API.Models.Views;
using Standard.Queries;
using Standard.Services;
using System;
using System.Threading.Tasks;

namespace Megaphone.API.Controllers
{
    internal class GetResourceListQuery : IQuery<IPartionedStorageService<ResourceListView>, ResourceListView>
    {
        const string CONTENT_KEY = "resources.json";
        string partitionKey = string.Empty;

        public GetResourceListQuery(DateTime date)
        {
            partitionKey = $"{date.Year}/{date.Month}/{date.Day}";
        }

        public async Task<ResourceListView> ExecuteAsync(IPartionedStorageService<ResourceListView> model)
        {
            var view = await model.GetAsync(partitionKey, CONTENT_KEY);
            return view ?? new ResourceListView();
        }
    }
}
