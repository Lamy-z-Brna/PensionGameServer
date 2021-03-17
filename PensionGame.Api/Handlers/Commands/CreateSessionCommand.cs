using PensionGame.Api.Handlers.Common;
using PensionGame.Api.Domain.Resources.Session;

namespace PensionGame.Api.Handlers.Commands
{
    public record CreateSessionCommand(StartupParameters? StartupParameters) : ICommand<SessionId>
    {
    }
}
