using PensionGame.Api.Common.Mappers.GameState;
using PensionGame.Api.Data_Access.Readers.GameData;
using PensionGame.Api.Domain.Resources.GameData;
using PensionGame.Api.Handlers.Queries;
using System.Threading.Tasks;

namespace PensionGame.Api.Handlers.QueryHandlers
{
    public sealed class GetGameStateQueryHandler : IGetGameStateQueryHandler
    {
        private readonly IGameStateReader _gameStateReader;
        private readonly IGameStateMapper _gameStateMapper;

        public GetGameStateQueryHandler(IGameStateReader gameStateReader, 
            IGameStateMapper gameStateMapper)
        {
            _gameStateReader = gameStateReader;
            _gameStateMapper = gameStateMapper;
        }

        public async Task<GameState?> Handle(GetGameStateQuery query)
        {
            var result = await _gameStateReader.GetCurrentGameState(query.SessionId);

            if (result == null)
                return null;

            return _gameStateMapper.Map(result);
        }
    }
}
