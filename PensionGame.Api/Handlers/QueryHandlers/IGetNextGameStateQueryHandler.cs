using PensionGame.Api.Handlers.Common;
using PensionGame.Api.Handlers.Queries;
using PensionGame.Core.Domain.GameData;

namespace PensionGame.Api.Handlers.QueryHandlers
{
    public interface IGetNextGameStateQueryHandler : IQueryHandler<GetNextGameStateQuery, GameState>
    {
    }
}
