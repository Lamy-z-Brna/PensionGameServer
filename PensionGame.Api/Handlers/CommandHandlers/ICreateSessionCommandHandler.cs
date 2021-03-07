using PensionGame.Api.Domain.Session;
using PensionGame.Api.Handlers.Commands;
using PensionGame.Api.Handlers.Common;

namespace PensionGame.Api.Handlers.CommandHandlers
{
    public interface ICreateSessionCommandHandler : ICommandHandler<CreateSessionCommand, SessionId>
    {
    }
}
