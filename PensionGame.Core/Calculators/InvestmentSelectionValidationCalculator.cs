using PensionGame.Core.Calculators.RequiredData;
using PensionGame.Core.Domain.ClientData;
using PensionGame.Core.Validation.Common;

namespace PensionGame.Core.Calculators
{
    public sealed class InvestmentSelectionValidationCalculator : IInvestmentSelectionValidationCalculator
    {
        private readonly IInvestmentSelectionDifferenceCalculator _investmentSelectionDifferenceCalculator;

        public InvestmentSelectionValidationCalculator(IInvestmentSelectionDifferenceCalculator investmentSelectionDifferenceCalculator)
        {
            _investmentSelectionDifferenceCalculator = investmentSelectionDifferenceCalculator;
        }

        public ValidationResult<InvestmentSelection> Calculate(InvestmentSelectionValidationRequiredData requiredData)
        {
            var currentClientData = requiredData.CurrentClientData;
            var investmentSelection = requiredData.InvestmentSelection;

            var holdingChanges = _investmentSelectionDifferenceCalculator.Calculate
                (
                    new InvestmentSelectionDifferenceRequiredData
                    (
                        CurrentHoldings: currentClientData.ClientHoldings, 
                        InvestmentSelection: investmentSelection
                    )
                );

            if (currentClientData.DisposableIncome + holdingChanges.LoanChange - holdingChanges.StockChange - holdingChanges.SavingsAccountChange - holdingChanges.BondChange < 0)
            {
                var totalInvested = holdingChanges.StockChange + holdingChanges.SavingsAccountChange + holdingChanges.BondChange;

                var errorMessage = holdingChanges.LoanChange >= 0
                    ? $"Total income usable of {currentClientData.DisposableIncome + holdingChanges.LoanChange} is not enough to cover investments totalling {totalInvested}"
                    : $"Total disposable income of {currentClientData.DisposableIncome} is not enough to cover investments and repayments totalling {totalInvested - holdingChanges.LoanChange}";

                return new ValidationResult<InvestmentSelection>
                (
                    new ValidationError
                    (
                        errorMessage
                    )
                );
            }

            if (holdingChanges.LoanChange > 0 && currentClientData.IncomeData.TotalIncome < investmentSelection.LoanValue)
                return new ValidationResult<InvestmentSelection>
                    (
                        new ValidationError
                        (
                            $"The requested loan value of {investmentSelection.LoanValue} would exceed the maximum of {currentClientData.IncomeData.TotalIncome}"
                        )
                    );

            return new ValidationResult<InvestmentSelection>(investmentSelection);
        }
    }
}
