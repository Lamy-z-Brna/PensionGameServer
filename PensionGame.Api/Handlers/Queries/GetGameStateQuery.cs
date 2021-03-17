using PensionGame.Api.Handlers.Common;
using PensionGame.Api.Domain.Resources.GameData;
using System;

namespace PensionGame.Api.Handlers.Queries
{
    public record GetGameStateQuery(Guid SessionId) : IQuery<GameState>
    {
    }
}
