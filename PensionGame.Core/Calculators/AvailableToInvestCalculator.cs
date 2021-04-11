using PensionGame.Core.Calculators.RequiredData;

namespace PensionGame.Core.Calculators
{
    public sealed class AvailableToInvestCalculator : IAvailableToInvestCalculator
    {
        private readonly IInvestmentSelectionDifferenceCalculator _investmentSelectionDifferenceCalculator;

        public AvailableToInvestCalculator(IInvestmentSelectionDifferenceCalculator investmentSelectionDifferenceCalculator)
        {
            _investmentSelectionDifferenceCalculator = investmentSelectionDifferenceCalculator;
        }

        public int Calculate(AvailableToInvestRequiredData requiredData)
        {
            var (currentClientData, investmentSelection) = requiredData;

            var differenceRequiredData = new InvestmentSelectionDifferenceRequiredData
                (
                    CurrentHoldings: currentClientData.ClientHoldings,
                    InvestmentSelection: investmentSelection
                );

            var holdingChanges = _investmentSelectionDifferenceCalculator.Calculate(differenceRequiredData);

            return currentClientData.DisposableIncome + holdingChanges.LoanChange - holdingChanges.StockChange - holdingChanges.SavingsAccountChange - holdingChanges.BondChange;
        }
    }
}
