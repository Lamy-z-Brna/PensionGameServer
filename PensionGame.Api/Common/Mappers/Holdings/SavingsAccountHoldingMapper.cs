namespace PensionGame.Api.Common.Mappers.Holdings
{
    public sealed class SavingsAccountHoldingMapper : ISavingsAccountHoldingMapper
    {
        public Domain.Resources.Holdings.SavingsAccountHoldings Map(Core.Domain.Holdings.SavingsAccountHoldings savingsAccountHoldings)
        {
            return new (savingsAccountHoldings.Amount);
        }

        public Core.Domain.Holdings.SavingsAccountHoldings Map(Domain.Resources.Holdings.SavingsAccountHoldings savingsAccountHoldings)
        {
            return new(savingsAccountHoldings.Amount);
        }
    }
}
