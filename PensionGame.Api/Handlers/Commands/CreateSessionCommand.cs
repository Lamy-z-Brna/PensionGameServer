using PensionGame.Api.Domain.Session;
using PensionGame.Api.Handlers.Common;

namespace PensionGame.Api.Handlers.Commands
{
    public record CreateSessionCommand(StartupParameters? StartupParameters) : ICommand<SessionId>
    {
    }
}
