using Castle.MicroKernel;
using PensionGame.Api.Handlers.Common;
using System.Threading.Tasks;

namespace PensionGame.Api.Handlers.Execution
{
    public sealed class Dispatcher : IDispatcher
    {
        private readonly IKernel _kernel;

        public Dispatcher(IKernel kernel)
        {
            _kernel = kernel;
        }

        public async Task Dispatch<TCommand>(TCommand command) where TCommand : ICommand
        {
            var commandHandler = _kernel.Resolve<ICommandHandler<TCommand>>();

            await commandHandler.Handle(command);
        }

        public async Task<TResult> Dispatch<TCommand, TResult>(TCommand command) where TCommand : ICommand<TResult>
        {
            var commandHandler = _kernel.Resolve<ICommandHandler<TCommand, TResult>>();

            return await commandHandler.Handle(command);
        }
    }
}
