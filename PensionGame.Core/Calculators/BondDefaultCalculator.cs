using PensionGame.Core.Calculators.RequiredData;
using PensionGame.Core.Common;
using PensionGame.Core.Domain.Holdings;
using PensionGame.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionGame.Core.Calculators
{
    public sealed class BondDefaultCalculator : IBondDefaultCalculator
    {
        private readonly IRandomSampler _randomSampler;

        public BondDefaultCalculator(IRandomSampler randomSampler)
        {
            _randomSampler = randomSampler;
        }

        public IEither<BondHolding, BondDefaultEvent> Calculate(BondDefaultRequiredData requiredData)
        {
            var (bond, bondDefaultRate) = requiredData;

            var hasDefaulted = _randomSampler.GenerateBernoulli(bondDefaultRate)
                .First();

            return hasDefaulted ? new Either<BondHolding, BondDefaultEvent>(new BondDefaultEvent(bond)) : new Either<BondHolding, BondDefaultEvent>(bond);
        }
    }
}
