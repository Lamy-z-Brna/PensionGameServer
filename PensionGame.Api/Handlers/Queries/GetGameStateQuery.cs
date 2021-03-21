﻿using PensionGame.Api.Handlers.Common;
using PensionGame.Api.Domain.Resources.GameData;
using PensionGame.Api.Domain.Resources.Session;

namespace PensionGame.Api.Handlers.Queries
{
    public record GetGameStateQuery(SessionId SessionId) : IQuery<GameState>
    {
    }
}
