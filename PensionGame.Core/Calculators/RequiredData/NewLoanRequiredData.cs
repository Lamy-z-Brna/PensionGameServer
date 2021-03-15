using PensionGame.Core.Domain.ClientData;
using PensionGame.Core.Domain.Holdings;

namespace PensionGame.Core.Calculators.RequiredData
{
    public record NewLoanRequiredData(LoanHoldings CurrentLoans, InvestmentSelection InvestmentSelection, double LoanInterestRate)
    {
    }
}
