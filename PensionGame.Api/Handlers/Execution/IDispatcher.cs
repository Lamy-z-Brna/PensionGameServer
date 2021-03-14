using PensionGame.Api.Handlers.Common;
using System.Threading.Tasks;

namespace PensionGame.Api.Handlers.Execution
{
    public interface IDispatcher
    {
        Task Dispatch<TCommand>(TCommand command) where TCommand : ICommand;

        Task<TResult> Dispatch<TCommand, TResult>(TCommand command) where TCommand : ICommand<TResult>;

        Task<TResult> Query<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>;
    }
}
