using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PensionGame.Core.Domain.Holdings
{
    public sealed record LoanHoldings(IEnumerable<LoanHolding> Loans) : IEnumerable<LoanHolding>
    {
        public int TotalLoanValue => Loans.Sum(loan => loan.Amount);

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
