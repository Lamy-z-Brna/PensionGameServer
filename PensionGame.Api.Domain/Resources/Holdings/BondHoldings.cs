using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PensionGame.Api.Domain.Resources.Holdings
{
    public record BondHoldings(IEnumerable<BondHolding> Bonds) : IEnumerable<BondHolding>
    {
        public BondHoldings() : this(Enumerable.Empty<BondHolding>()) { }

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
