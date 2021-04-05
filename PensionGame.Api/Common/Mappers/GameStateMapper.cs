using AutoMapper;
using PensionGame.Api.Common.Helpers;
using PensionGame.Api.Domain.Resources.ClientData;
using PensionGame.Api.Domain.Resources.GameData;
using PensionGame.Api.Domain.Resources.MarketData;
using PensionGame.Core.Events.Common;
using System.Linq;

namespace PensionGame.Api.Common.Mappers
{
    public sealed class GameStateMapper : IGameStateMapper
    {
        private readonly IMapper _mapper;
        private readonly IEventMapper _eventMapper;

        public GameStateMapper(IMapper mapper, 
            IEventMapper eventMapper)
        {
            _mapper = mapper;
            _eventMapper = eventMapper;
        }

        public Core.Domain.GameData.GameState Map(GameState gameState)
        {
            return new Core.Domain.GameData.GameState
                (
                    Year: gameState.Year,
                    ClientData: _mapper.Map<Core.Domain.ClientData.ClientData>(gameState.ClientData),
                    MarketData: _mapper.Map<Core.Domain.MarketData.MarketData>(gameState.MarketData),
                    IsFinished: gameState.IsFinished,
                    Events: Enumerable.Empty<IEvent>()
                );
        }

        GameState IMapper<Core.Domain.GameData.GameState, GameState>.Map(Core.Domain.GameData.GameState gameState)
        {
            return new GameState
                (
                    Year: gameState.Year,
                    ClientData: _mapper.Map<ClientData>(gameState.ClientData),
                    MarketData: _mapper.Map<MarketData>(gameState.MarketData),
                    IsFinished: gameState.IsFinished,
                    Events: _eventMapper.Map(gameState.Events)
                );
        }
    }
}
