using PensionGame.Api.Common.Mappers.MarketData;
using PensionGame.Api.Data_Access.Readers.GameData;
using PensionGame.Api.Domain.Resources.MarketData;
using PensionGame.Api.Handlers.Queries;
using PensionGame.Core.Calculators.MarketData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionGame.Api.Handlers.QueryHandlers
{
    public sealed class GetAverageInflationRateQueryHandler : IGetAverageInflationRateQueryHandler
    {
        private readonly IGameStateReader _gameStateReader;
        private readonly IAverageInflationRateCalculator _averageInflationRateCalculator;
        private readonly IAverageInflationRateMapper _averageInflationRateMapper;

        public GetAverageInflationRateQueryHandler(IGameStateReader gameStateReader,
            IAverageInflationRateCalculator averageInflationRateCalculator, 
            IAverageInflationRateMapper averageInflationRateMapper)
        {
            _gameStateReader = gameStateReader;
            _averageInflationRateCalculator = averageInflationRateCalculator;
            _averageInflationRateMapper = averageInflationRateMapper;
        }

        public async Task<AverageInflationRate?> Handle(GetAverageInflationRateQuery query)
        {
            var gameStates = await _gameStateReader.Get(query.SessionId);

            if (!gameStates.Any())
                return null;

            var averageInflationRate = _averageInflationRateCalculator.Calculate(new(gameStates.Values));

            if (averageInflationRate == null)
                return null;

            return _averageInflationRateMapper.Map(averageInflationRate);
        }
    }
}
