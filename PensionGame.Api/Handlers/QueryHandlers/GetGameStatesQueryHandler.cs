using PensionGame.Api.Common.Mappers;
using PensionGame.Api.Data_Access.Readers.GameData;
using PensionGame.Api.Domain.Resources.GameData;
using PensionGame.Api.Handlers.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PensionGame.Api.Handlers.QueryHandlers
{
    public sealed class GetGameStatesQueryHandler : IGetGameStatesQueryHandler
    {
        private readonly IGameStateReader _gameStateReader;
        private readonly IDictionaryMapper<int, Core.Domain.GameData.GameState, GameState> _dictionaryMapper;

        public GetGameStatesQueryHandler(IGameStateReader gameStateReader, 
            IDictionaryMapper<int, Core.Domain.GameData.GameState, GameState> dictionaryMapper)
        {
            _gameStateReader = gameStateReader;
            _dictionaryMapper = dictionaryMapper;
        }

        public async Task<Dictionary<int, GameState>> Handle(GetGameStatesQuery query)
        {
            var result = await _gameStateReader.Get(query.SessionId);

            return _dictionaryMapper.Map(result);
        }
    }
}
