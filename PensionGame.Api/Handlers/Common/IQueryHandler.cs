using System.Threading.Tasks;

namespace PensionGame.Api.Handlers.Common
{
    public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        Task<TResult> Handle(TQuery query);
    }
}
