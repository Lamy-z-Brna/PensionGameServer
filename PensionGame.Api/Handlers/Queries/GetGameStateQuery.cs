using PensionGame.Api.Handlers.Common;
using PensionGame.Api.Resources.GameData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionGame.Api.Handlers.Queries
{
    public record GetGameStateQuery(Guid SessionId) : IQuery<GameState>
    {
    }
}
