using PensionGame.Api.Domain.Resources.Session;
using PensionGame.Api.Handlers.Common;

namespace PensionGame.Api.Handlers.Queries
{
    public record GetSessionQuery(SessionId SessionId) : IQuery<Session?>
    {
    }
}
