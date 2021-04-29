using PensionGame.Common.Functional;
using PensionGame.Core.Calculators.RequiredData;
using PensionGame.Core.Common;
using PensionGame.Core.Domain.Holdings;
using PensionGame.Core.Events;
using System.Linq;

namespace PensionGame.Core.Calculators
{
    public sealed class BondDefaultCalculator : IBondDefaultCalculator
    {
        private readonly IRandomSampler _randomSampler;

        public BondDefaultCalculator(IRandomSampler randomSampler)
        {
            _randomSampler = randomSampler;
        }

        public Union<BondHolding, BondDefaultEvent> Calculate(BondDefaultRequiredData requiredData)
        {
            var (bond, bondDefaultRate) = requiredData;

            var hasDefaulted = _randomSampler.GenerateBernoulli(bondDefaultRate)
                .First();

            return hasDefaulted ? new BondDefaultEvent(bond) : bond;
        }
    }
}
