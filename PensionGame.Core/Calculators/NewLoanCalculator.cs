using PensionGame.Core.Calculators.RequiredData;
using PensionGame.Core.Domain.Holdings;
using System.Collections.Generic;
using System.Linq;

namespace PensionGame.Core.Calculators
{
    public sealed class NewLoanCalculator : INewLoanCalculator
    {
        public LoanHoldings Calculate(NewLoanRequiredData requiredData)
        {
            var currentLoans = requiredData.CurrentLoans;
            var currentLoanTotal = currentLoans.TotalLoanValue;
            var investmentSelection = requiredData.InvestmentSelection.LoanValue;
            var loanInterestRate = requiredData.LoanInterestRate;

            var refinancedLoans = Refinance(currentLoans, loanInterestRate);

            var loanAmountChange = investmentSelection - currentLoanTotal;


            switch (loanAmountChange)
            {
                case int toBorrow when toBorrow > 0:
                    return AddNewLoan(refinancedLoans, toBorrow, loanInterestRate);
                case int toRepay when toRepay < 0:
                    return RepayLoans(refinancedLoans, -toRepay);
                case int _:
                    return refinancedLoans;
            }    
        }

        private static LoanHoldings Refinance(LoanHoldings currentLoans, double loanInterestRate)
        {
            var loansByRefinance = currentLoans.ToLookup(loan => loan.InterestRate > loanInterestRate);
            var totalToRefinance = new LoanHoldings(loansByRefinance[true]).TotalLoanValue;

            var result = new LoanHoldings
                (
                    loansByRefinance[false]
                    .Append(new LoanHolding(totalToRefinance, loanInterestRate))
                    .Where(loan => loan.Amount > 0)
                );

            return result;
        }

        private static LoanHoldings AddNewLoan(LoanHoldings currentLoans, int loanAmountChange, double loanInterestRate)
        {
            var newLoans = currentLoans
                .Append(new LoanHolding(loanAmountChange, loanInterestRate))
                .GroupBy(loan => loan.InterestRate)
                .ToDictionary(interest => interest.Key, g => g.Sum(loan => loan.Amount))
                .Select(kv => new LoanHolding(kv.Value, kv.Key));

            return new LoanHoldings(newLoans);
        }

        private static LoanHoldings RepayLoans(LoanHoldings currentLoans, int amountToRepay)
        {
            return new LoanHoldings(RepayLoansInternal(currentLoans, amountToRepay));
        }

        private static IEnumerable<LoanHolding> RepayLoansInternal(LoanHoldings currentLoans, int amountToRepay)
        {
            foreach (var loan in currentLoans.OrderByDescending(loan => loan.InterestRate))
            {
                if (amountToRepay >= loan.Amount)
                {
                    amountToRepay -= loan.Amount;
                }
                else if (amountToRepay < loan.Amount && amountToRepay > 0)
                {
                    var newLoanAmount = loan.Amount - amountToRepay;

                    amountToRepay = 0;

                    yield return loan with { Amount = newLoanAmount };
                }
                else
                {
                    yield return loan;
                }
            }
        }
    }
}
