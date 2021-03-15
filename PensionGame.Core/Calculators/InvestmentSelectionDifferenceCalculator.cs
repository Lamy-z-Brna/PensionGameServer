using PensionGame.Core.Calculators.RequiredData;
using PensionGame.Core.Domain.ClientData;

namespace PensionGame.Core.Calculators
{
    public sealed class InvestmentSelectionDifferenceCalculator : IInvestmentSelectionDifferenceCalculator
    {
        public InvestmentSelectionDifference Calculate(InvestmentSelectionDifferenceRequiredData requiredData)
        {
            var currentHoldings = requiredData.CurrentHoldings;
            var investmentSelection = requiredData.InvestmentSelection;

            var stockChange = investmentSelection.StockValue - currentHoldings.Stocks.Value;
            var bondChange = investmentSelection.BondValue;
            var savingsChange = investmentSelection.SavingsAccountValue - currentHoldings.SavingsAccount.Amount;
            var loanChange = investmentSelection.LoanValue - currentHoldings.TotalLoanValue;

            return new InvestmentSelectionDifference
                (
                    StockChange: stockChange,
                    BondChange: bondChange,
                    SavingsAccountChange: savingsChange,
                    LoanChange: loanChange
                );
        }
    }
}
