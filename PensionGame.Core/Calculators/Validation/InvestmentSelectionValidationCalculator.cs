using PensionGame.Core.Calculators.RequiredData;
using PensionGame.Core.Domain.ClientData;
using PensionGame.Core.Validation.Common;

namespace PensionGame.Core.Calculators.Validation
{
    public sealed class InvestmentSelectionValidationCalculator : IInvestmentSelectionValidationCalculator
    {
        private readonly IAvailableToInvestCalculator _availableToInvestCalculator;
        private readonly IInvestmentSelectionDifferenceCalculator _investmentSelectionDifferenceCalculator;

        public InvestmentSelectionValidationCalculator(IAvailableToInvestCalculator availableToInvestCalculator, 
            IInvestmentSelectionDifferenceCalculator investmentSelectionDifferenceCalculator)
        {
            _availableToInvestCalculator = availableToInvestCalculator;
            _investmentSelectionDifferenceCalculator = investmentSelectionDifferenceCalculator;
        }

        public ValidationResult<InvestmentSelection> Calculate(InvestmentSelectionValidationRequiredData requiredData)
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

            var (stockChange, bondChange, savingsAccountChange, loanChange) = _investmentSelectionDifferenceCalculator.Calculate
                (
                    new InvestmentSelectionDifferenceRequiredData
                    (
                        CurrentHoldings: currentClientData.ClientHoldings,
                        InvestmentSelection: investmentSelection
                    )
                );

            var requiresNewLoan = loanChange > 0;

            if (availableToInvest < 0)
            {
                var totalInvested = stockChange + bondChange + savingsAccountChange;

                var errorMessage = requiresNewLoan
                    ? $"Total income usable of {currentClientData.DisposableIncome + loanChange} is not enough to cover investments totalling {totalInvested}"
                    : $"Total disposable income of {currentClientData.DisposableIncome} is not enough to cover investments and repayments totalling {totalInvested - loanChange}";

                return new ValidationResult<InvestmentSelection>
                (
                    new ValidationError
                    (
                        errorMessage
                    )
                );
            }

            if (requiresNewLoan && currentClientData.IncomeData.ActualSalary < investmentSelection.LoanValue)
                return new ValidationResult<InvestmentSelection>
                    (
                        new ValidationError
                        (
                            $"The requested loan value of {investmentSelection.LoanValue} would exceed the maximum of {currentClientData.IncomeData.ActualSalary} equal to current salary"
                        )
                    );

            return new ValidationResult<InvestmentSelection>(investmentSelection);
        }
    }
}
