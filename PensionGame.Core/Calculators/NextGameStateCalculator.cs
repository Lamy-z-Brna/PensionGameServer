using PensionGame.Core.Calculators.RequiredData;
using PensionGame.Core.Domain.GameData;
using PensionGame.Core.Domain.MarketData;
using PensionGame.Core.Events.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionGame.Core.Calculators
{
    public sealed class NextGameStateCalculator : INextGameStateCalculator
    {
        private readonly IMacroEconomicDataCalculator _macroEconomicDataCalculator;      
        private readonly IReturnDataCalculator _returnDataCalculator;
        private readonly IClientDataCalculator _clientDataCalculator;

        public NextGameStateCalculator(IMacroEconomicDataCalculator macroEconomicDataCalculator, 
            IReturnDataCalculator returnDataCalculator, 
            IClientDataCalculator clientDataCalculator)
        {
            _macroEconomicDataCalculator = macroEconomicDataCalculator;
            _returnDataCalculator = returnDataCalculator;
            _clientDataCalculator = clientDataCalculator;
        }

        public GameState Calculate(NextGameStateRequiredData requiredData)
        {
            var (previousGameState, investmentSelection) = requiredData;

            var newMacroEconomicData = _macroEconomicDataCalculator.Calculate();
            var newReturnData = _returnDataCalculator.Calculate(newMacroEconomicData);

            var clientDataRequiredData = new ClientDataRequiredData
                (
                    PreviousClientData: previousGameState.ClientData,
                    PreviousMarketData: previousGameState.MarketData,
                    InvestmentSelection: investmentSelection,
                    MacroEconomicData: newMacroEconomicData,
                    ReturnData: newReturnData,
                    Events: Enumerable.Empty<IEvent>()
                );

            var newClientData = _clientDataCalculator.Calculate(clientDataRequiredData);
            var newMarketData = new MarketData(newMacroEconomicData, newReturnData);

            return new GameState(previousGameState.Year + 1, newClientData, newMarketData, previousGameState.Year + 1 >= 65);
        }
    }
}
