using PensionGame.Common.Functional;
using PensionGame.Core.Calculators.Common;
using PensionGame.Core.Calculators.RequiredData;
using PensionGame.Core.Domain.Holdings;
using PensionGame.Core.Events;

namespace PensionGame.Core.Calculators
{
    public interface IBondDefaultCalculator : ICalculator<BondDefaultRequiredData, Union<BondHolding, BondDefaultEvent>>
    {
    }
}
