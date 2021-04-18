using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PensionGame.Api.Domain.Resources.Holdings
{
    public record LoanHoldings(IReadOnlyCollection<LoanHolding> Loans) : IReadOnlyCollection<LoanHolding>
    {
        public LoanHoldings(IEnumerable<LoanHolding> loans) : this(loans.ToList()) { }

        public LoanHoldings() : this(Array.Empty<LoanHolding>()) { }

        public int TotalLoanValue => Loans.Sum(loan => loan.Amount);

        public int Count => Loans.Count;

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
