using System.Threading.Tasks;

namespace Standard.Queries
{
    public interface IQuery<in TModel, TResult>
    {
        Task<TResult> ExecuteAsync(TModel model);
    }
}