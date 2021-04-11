using PensionGame.Api.Domain.Resources.Session;
using PensionGame.Api.Handlers.Common;

namespace PensionGame.Api.Handlers.Commands
{
    public record CreateSessionCommand(string Name, StartupParameters? StartupParameters) : ICommand<SessionId>
    {
    }
}
