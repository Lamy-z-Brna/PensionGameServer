using PensionGame.Core.Calculators.RequiredData;
using PensionGame.Core.Domain.Holdings;
using PensionGame.Core.Events.Common;
using PensionGame.Core.Events.PreClientDataEvents;
using System;
using System.Collections.Generic;

namespace PensionGame.Core.Calculators
{
    public sealed class NewSavingsAccountCalculator : INewSavingsAccountCalculator
    {
        private readonly IAvailableToInvestCalculator _availableToInvestCalculator;

        public NewSavingsAccountCalculator(IAvailableToInvestCalculator availableToInvestCalculator)
        {
            _availableToInvestCalculator = availableToInvestCalculator;
        }

        public (SavingsAccountHoldings SavingsAccountHoldings, IReadOnlyCollection<IEvent> Events) Calculate(NewSavingsAccountRequiredData requiredData)
        {
            var (currentClientData, investmentSelection) = requiredData;

            var availableToInvest = _availableToInvestCalculator.Calculate
                (
                    new AvailableToInvestRequiredData
                    (
                        CurrentClientData: currentClientData,
                        InvestmentSelection: investmentSelection
                    )
                );
            var amountRequested = investmentSelection.SavingsAccountValue;

            var newSavingsAccountValue = amountRequested + availableToInvest;

            return (
                    new SavingsAccountHoldings(newSavingsAccountValue),
                    availableToInvest > 0 
                        ? new[] { new AutomaticSavingsAccountInvestmentEvent(amountRequested, availableToInvest) }
                        : Array.Empty<IEvent>()
                );
        }
    }
}
