using PensionGame.Core.Calculators.ClientData;
using PensionGame.Core.Calculators.Events;
using PensionGame.Core.Calculators.MarketData;
using PensionGame.Core.Calculators.RequiredData;
using System.Linq;

namespace PensionGame.Core.Calculators.GameState
{
    public sealed class NextGameStateCalculator : INextGameStateCalculator
    {
        private readonly IMarketDataCalculator _marketDataGenerator;
        private readonly IClientDataCalculator _clientDataCalculator;
        private readonly IPreClientDataEventCalculator _preClientDataEventCalculator;

        public NextGameStateCalculator(IMarketDataCalculator marketDataCalculator,
            IClientDataCalculator clientDataCalculator,
            IPreClientDataEventCalculator preClientDataEventCalculator)
        {
            _marketDataGenerator = marketDataCalculator;
            _clientDataCalculator = clientDataCalculator;
            _preClientDataEventCalculator = preClientDataEventCalculator;
        }

        public Domain.GameData.GameState Calculate(NextGameStateRequiredData requiredData)
        {
            var (previousGameState, investmentSelection) = requiredData;

            if (previousGameState.IsFinished)
                return previousGameState;

            var (newMarketData, events) = _marketDataGenerator.Calculate();

            var clientDataEvents = _preClientDataEventCalculator
                .Calculate(newMarketData.MacroEconomicData)
                .Union(events)
                .ToList();

            var clientDataRequiredData = new ClientDataRequiredData
                (
                    PreviousClientData: previousGameState.ClientData,
                    PreviousMarketData: previousGameState.MarketData,
                    InvestmentSelection: investmentSelection,
                    MarketData: newMarketData,
                    Events: clientDataEvents
                );

            var (newClientData, clientEvents) = _clientDataCalculator.Calculate(clientDataRequiredData);
            var newYear = previousGameState.Year + 1;

            return new 
                (
                    Year: newYear,
                    RetirementYear: previousGameState.RetirementYear, 
                    ClientData: newClientData, 
                    MarketData: newMarketData,
                    Events: clientDataEvents.Union(clientEvents).ToList()
                );
        }
    }
}
