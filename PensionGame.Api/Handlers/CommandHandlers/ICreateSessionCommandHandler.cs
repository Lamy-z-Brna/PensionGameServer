using PensionGame.Api.Handlers.Commands;
using PensionGame.Api.Handlers.Common;
using PensionGame.Api.Domain.Resources.Session;

namespace PensionGame.Api.Handlers.CommandHandlers
{
    public interface ICreateSessionCommandHandler : ICommandHandler<CreateSessionCommand, SessionId>
    {
    }
}
