using PensionGame.Api.Domain.Resources.GameData;
using PensionGame.Api.Handlers.Common;
using PensionGame.Api.Handlers.Queries;
using System.Collections.Generic;

namespace PensionGame.Api.Handlers.QueryHandlers
{
    public interface IGetGameStatesQueryHandler : IQueryHandler<GetGameStatesQuery, Dictionary<int, GameState>>
    {
    }
}
