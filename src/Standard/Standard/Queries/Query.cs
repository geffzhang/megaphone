using System.Threading.Tasks;

namespace Standard.Queries
{
    internal abstract class Query<TModel, TResult> : IQuery<TModel, TResult>
    {
        public abstract Task<TResult> ExecuteAsync(TModel model);
    }
}