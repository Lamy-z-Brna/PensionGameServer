﻿using PensionGame.Api.Handlers.Common;
using PensionGame.Api.Handlers.Queries;
using PensionGame.Api.Resources.GameData;

namespace PensionGame.Api.Handlers.QueryHandlers
{
    public interface IGetGameStateQueryHandler : IQueryHandler<GetGameStateQuery, GameState>
    {
    }
}
