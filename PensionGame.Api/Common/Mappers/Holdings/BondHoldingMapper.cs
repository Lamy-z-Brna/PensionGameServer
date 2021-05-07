namespace PensionGame.Api.Common.Mappers.Holdings
{
    public sealed class BondHoldingMapper : IBondHoldingMapper
    {
        public Domain.Resources.Holdings.BondHolding Map(Core.Domain.Holdings.BondHolding bondHolding)
        {
            return new (
                YearlyPayment: bondHolding.YearlyPayment, 
                YearsToExpiration: bondHolding.YearsToExpiration
                );
        }

        public Core.Domain.Holdings.BondHolding Map(Domain.Resources.Holdings.BondHolding bondHolding)
        {
            return new(
                YearlyPayment: bondHolding.YearlyPayment,
                YearsToExpiration: bondHolding.YearsToExpiration
                );
        }
    }
}
