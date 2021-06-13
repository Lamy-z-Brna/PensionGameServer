using PensionGame.Core.Calculators.RequiredData;
using PensionGame.Core.Domain.MarketData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionGame.Core.Calculators.MarketData
{
    public sealed class AverageInflationRateCalculator : IAverageInflationRateCalculator
    {
        public AverageInflationRate? Calculate(AverageInflationRateRequiredData requiredData)
        {
            var gameStates = requiredData.GameStates;

            if (!gameStates.Any())
                return null;

            var firstGameYear = gameStates.Min(game => game.Year);
            var lastGameYear = gameStates.Max(game => game.Year);
            var yearsPassed = (double)lastGameYear - firstGameYear;

            var totalInflation = gameStates
                .Where(gameState => !gameState.IsInitial)
                .Select(gameState => gameState.MarketData.MacroEconomicData.InflationRate)
                .Aggregate(1d, (a, b) => a * (1 + b));

            var averageInflation = Math.Pow(totalInflation, 1 / yearsPassed);
            return new(averageInflation);
        }
    }
}
