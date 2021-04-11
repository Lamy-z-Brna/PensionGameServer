using PensionGame.Core.Calculators.RequiredData;

namespace PensionGame.Core.Calculators
{
    public sealed class InvestmentSelectionDifferenceCalculator : IInvestmentSelectionDifferenceCalculator
    {
        public (int StockChange, int BondChange, int SavingsAccountChange, int LoanChange) Calculate(InvestmentSelectionDifferenceRequiredData requiredData)
        {
            var currentHoldings = requiredData.CurrentHoldings;
            var investmentSelection = requiredData.InvestmentSelection;

            var stockChange = investmentSelection.StockValue - currentHoldings.Stocks.Value;
            var bondChange = investmentSelection.BondValue;
            var savingsChange = investmentSelection.SavingsAccountValue - currentHoldings.SavingsAccount.Amount;
            var loanChange = investmentSelection.LoanValue - currentHoldings.TotalLoanValue;

            return new 
                (
                    stockChange,
                    bondChange,
                    savingsChange,
                    loanChange
                );
        }
    }
}
