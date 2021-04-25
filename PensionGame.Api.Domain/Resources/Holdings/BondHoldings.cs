using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PensionGame.Api.Domain.Resources.Holdings
{
    public record BondHoldings(IReadOnlyCollection<BondHolding> Bonds) : IReadOnlyCollection<BondHolding>
    {
        public BondHoldings(IEnumerable<BondHolding> bonds) : this(bonds.ToList()) { }

        public BondHoldings() : this(Array.Empty<BondHolding>()) { }

        public int Count => Bonds.Count;

        public int Value => Bonds.Sum(bond => bond.Value);

        public IEnumerator<BondHolding> GetEnumerator()
        {
            return Bonds.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Bonds.GetEnumerator();
        }
    }
}
