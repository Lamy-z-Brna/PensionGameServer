using PensionGame.Api.Common.Helpers;
using PensionGame.Api.Common.Mappers.ClientData;
using PensionGame.Api.Common.Mappers.Events;
using PensionGame.Api.Common.Mappers.MarketData;
using PensionGame.Core.Events.Common;
using System;

namespace PensionGame.Api.Common.Mappers.GameState
{
    public sealed class GameStateMapper : IGameStateMapper
    {
        private readonly IClientDataMapper _clientDataMapper; 
        private readonly IMarketDataMapper _marketDataMapper;
        private readonly IEventMapper _eventMapper;

        public GameStateMapper(IClientDataMapper clientDataMapper, IMarketDataMapper marketDataMapper, IEventMapper eventMapper)
        {
            _clientDataMapper = clientDataMapper;
            _marketDataMapper = marketDataMapper;
            _eventMapper = eventMapper;
        }

        public Core.Domain.GameData.GameState Map(Domain.Resources.GameData.GameState gameState)
        {
            return new 
                (
                    Year: gameState.Year,
                    RetirementYear: gameState.RetirementYear,
                    ClientData: _clientDataMapper.Map(gameState.ClientData),
                    MarketData: _marketDataMapper.Map(gameState.MarketData),
                    Events: Array.Empty<IEvent>()
                );
        }

        public Domain.Resources.GameData.GameState Map(Core.Domain.GameData.GameState gameState)
        {
            return new (
                    Year: gameState.Year,
                    RetirementYear: gameState.RetirementYear,
                    ClientData: _clientDataMapper.Map(gameState.ClientData),
                    MarketData: _marketDataMapper.Map(gameState.MarketData),
                    Events: _eventMapper.Map(gameState.Events)
                );
        }
    }
}
