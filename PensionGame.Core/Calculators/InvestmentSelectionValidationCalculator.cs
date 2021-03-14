using PensionGame.Core.Calculators.RequiredData;
using PensionGame.Core.Domain.ClientData;
using PensionGame.Core.Validation.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionGame.Core.Calculators
{
    public sealed class InvestmentSelectionValidationCalculator : IInvestmentSelectionValidationCalculator
    {
        public ValidationResult<InvestmentSelection> Calculate(InvestmentSelectionValidationRequiredData requiredData)
        {
            var currentClientData = requiredData.CurrentClientData;
            var investmentSelection = requiredData.InvestmentSelection;

            var newLoanValue = investmentSelection.LoanValue - currentClientData.ClientHoldings.TotalLoanValue;
            var totalDisposableIncome = newLoanValue + currentClientData.DisposableIncome;
            var totalInvestedAmount = investmentSelection.TotalInvestedValue;

            if (totalDisposableIncome < totalInvestedAmount)
                return new ValidationResult<InvestmentSelection>
                    (
                        new ValidationError
                        (
                            $"Total invested amount of {totalInvestedAmount} exceeds disposable income of {totalDisposableIncome}"
                        )
                    );



            if (newLoanValue > 0 && currentClientData.IncomeData.TotalIncome < investmentSelection.LoanValue)
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
