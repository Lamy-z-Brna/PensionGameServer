using PensionGame.Api.Domain.Resources.GameData;
using PensionGame.Api.Handlers.Common;
using PensionGame.Api.Handlers.Queries;

namespace PensionGame.Api.Handlers.QueryHandlers
{
    public interface IGetNextGameStateQueryHandler : IQueryHandler<GetNextGameStateQuery, GameState>
    {
    }
}
