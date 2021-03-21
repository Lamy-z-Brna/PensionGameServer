using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PensionGame.Api.Domain.Resources.Holdings
{
    public record LoanHoldings(IEnumerable<LoanHolding> Loans) : IEnumerable<LoanHolding>
    {
        public LoanHoldings() : this(Enumerable.Empty<LoanHolding>()) { }

        public int TotalLoanValue => Loans.Sum(loan => loan.Amount);

        public IEnumerator<LoanHolding> GetEnumerator()
        {
            return Loans.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Loans.GetEnumerator();
        }
    }
}
