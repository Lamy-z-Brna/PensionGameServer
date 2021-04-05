using PensionGame.Api.Data_Access.Readers.GameData;
using PensionGame.Api.Domain.Resources.GameData;
using PensionGame.Api.Handlers.Queries;
using System.Threading.Tasks;

namespace PensionGame.Api.Handlers.QueryHandlers
{
    public sealed class GetGameStateQueryHandler : IGetGameStateQueryHandler
    {
        private readonly IGameStateReader _gameStateReader;

        public GetGameStateQueryHandler(IGameStateReader gameStateReader)
        {
            _gameStateReader = gameStateReader;
        }

        public async Task<GameState?> Handle(GetGameStateQuery query)
        {
            return await _gameStateReader.GetCurrentGameState(query.SessionId);
        }
    }
}
