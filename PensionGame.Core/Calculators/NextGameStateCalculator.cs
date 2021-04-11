using PensionGame.Core.Calculators.RequiredData;
using PensionGame.Core.Domain.GameData;
using System.Linq;

namespace PensionGame.Core.Calculators
{
    public sealed class NextGameStateCalculator : INextGameStateCalculator
    {
        private readonly IMarketDataGenerator _marketDataGenerator;
        private readonly IClientDataCalculator _clientDataCalculator;
        private readonly IPreClientDataEventCalculator _preClientDataEventCalculator;

        public NextGameStateCalculator(IMarketDataGenerator marketDataCalculator,
            IClientDataCalculator clientDataCalculator, 
            IPreClientDataEventCalculator preClientDataEventCalculator)
        {
            _marketDataGenerator = marketDataCalculator;
            _clientDataCalculator = clientDataCalculator;
            _preClientDataEventCalculator = preClientDataEventCalculator;
        }

        public GameState Calculate(NextGameStateRequiredData requiredData)
        {
            var (previousGameState, investmentSelection) = requiredData;

            if (previousGameState.IsFinished)
                return previousGameState;

            var (newMarketData, events) = _marketDataGenerator.Generate();

            var clientDataEvents = _preClientDataEventCalculator.Calculate(newMarketData.MacroEconomicData).Union(events);

            var clientDataRequiredData = new ClientDataRequiredData
                (
                    PreviousClientData: previousGameState.ClientData,
                    PreviousMarketData: previousGameState.MarketData,
                    InvestmentSelection: investmentSelection,
                    MarketData: newMarketData,
                    Events: clientDataEvents
                );

            var (newClientData, clientEvents) = _clientDataCalculator.Calculate(clientDataRequiredData);

            return new GameState(previousGameState.Year + 1, newClientData, newMarketData, previousGameState.Year + 1 >= 65, clientDataEvents.Union(clientEvents));
        }
    }
}
