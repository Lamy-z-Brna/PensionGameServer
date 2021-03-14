using PensionGame.Api.Handlers.Queries;
using PensionGame.Api.Resources.GameData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionGame.Api.Handlers.QueryHandlers
{
    public sealed class GetGameStateQueryHandler : IGetGameStateQueryHandler
    {
        public Task<GameState> Handle(GetGameStateQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
