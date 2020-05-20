using System.Threading.Tasks;

namespace Standard.Commands
{
    public interface ICommand<in TModel>
    {
        Task ApplyAsync(TModel model);
    }
}