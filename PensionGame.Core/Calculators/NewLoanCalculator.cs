using PensionGame.Core.Calculators.RequiredData;
using PensionGame.Core.Common;
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
            var loanAmountChange = investmentSelection - currentLoanTotal;

            LoanHoldings refinance(LoanHoldings loanHoldings) => Refinance(loanHoldings, loanInterestRate);
            LoanHoldings addNewLoan(LoanHoldings loanHoldings) => AddNewLoan(loanHoldings, loanAmountChange, loanInterestRate);
            LoanHoldings repayLoans(LoanHoldings loanHoldings) => RepayLoans(loanHoldings, -loanAmountChange);
            LoanHoldings processLoans(LoanHoldings loanHoldings) => loanAmountChange > 0 ? addNewLoan(loanHoldings) : repayLoans(loanHoldings);

            return currentLoans.Pipe
                (
                    refinance,
                    processLoans,
                    MergeLoans
                );
        }

        private static LoanHoldings Refinance(LoanHoldings currentLoans, double loanInterestRate)
        {
            var loansByRefinance = currentLoans.ToLookup(loan => loan.InterestRate > loanInterestRate);
            var totalToRefinance = new LoanHoldings(loansByRefinance[true].ToList()).TotalLoanValue;

            var result = loansByRefinance[false]
                .Append(new LoanHolding(totalToRefinance, loanInterestRate))
                .Where(loan => loan.Amount > 0)
                .ToLoans();

            return result;
        }

        private static LoanHoldings AddNewLoan(LoanHoldings currentLoans, int loanAmountChange, double loanInterestRate)
        {
            var newLoans = currentLoans
                .Append(new LoanHolding(loanAmountChange, loanInterestRate))
                .ToLoans();

            return newLoans;
        }

        private static LoanHoldings RepayLoans(LoanHoldings currentLoans, int amountToRepay)
        {
            return RepayLoansInternal(currentLoans, amountToRepay)
                .ToLoans();
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

        private static LoanHoldings MergeLoans(LoanHoldings loanHoldings)
        {
            return loanHoldings
                .GroupBy(loan => loan.InterestRate)
                .ToDictionary(interest => interest.Key, g => g.Sum(loan => loan.Amount))
                .Select(kv => new LoanHolding(kv.Value, kv.Key))
                .ToLoans();
        }
    }
}
