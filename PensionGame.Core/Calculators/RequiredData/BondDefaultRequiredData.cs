using PensionGame.Core.Domain.Holdings;

namespace PensionGame.Core.Calculators.RequiredData
{
    public record BondDefaultRequiredData(BondHolding BondHolding, double BondDefaultRate)
    {
    }
}
