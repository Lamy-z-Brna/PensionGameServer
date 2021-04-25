using PensionGame.Api.Domain.Resources.GameData;
using PensionGame.Api.Domain.Resources.Session;
using PensionGame.Api.Handlers.Common;
using System.Collections.Generic;

namespace PensionGame.Api.Handlers.Queries
{
    public record GetGameStatesQuery(SessionId SessionId) : IQuery<Dictionary<int, GameState>>
    {        
    }
}
