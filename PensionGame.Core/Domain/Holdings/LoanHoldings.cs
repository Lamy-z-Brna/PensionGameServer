using PensionGame.Core.Common;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PensionGame.Core.Domain.Holdings
{
    public sealed record LoanHoldings(IReadOnlyCollection<LoanHolding> Loans) : IReadOnlyCollection<LoanHolding>
    {
        public LoanHoldings(IEnumerable<LoanHolding> loans) : this(loans.ToList()) { }

        public int TotalLoanValue => Loans.Sum(loan => loan.Amount);

        public int TotalInterestValue => Loans.Sum(loan => Rounder.Round(loan.Amount * loan.InterestRate));

        public int Count => Loans.Count;

        public IEnumerator<LoanHolding> GetEnumerator()
        {
            return Loans.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Loans.GetEnumerator();
        }

        public bool Equals(LoanHoldings? other)
        {
            if (other == null)
                return false;

            return Enumerable.SequenceEqual(Loans, other.Loans);
        }

        public override int GetHashCode()
        {
            return Loans.GetHashCode();
        }
    }
}
