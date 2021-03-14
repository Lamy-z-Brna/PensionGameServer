using PensionGame.Api.Handlers.Common;
using PensionGame.Api.Handlers.Queries;
using PensionGame.Api.Resources.GameData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionGame.Api.Handlers.QueryHandlers
{
    public interface IGetGameStateQueryHandler : IQueryHandler<GetGameStateQuery, GameState>
    {
    }
}
