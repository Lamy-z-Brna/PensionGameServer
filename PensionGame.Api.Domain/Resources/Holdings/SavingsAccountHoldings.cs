namespace PensionGame.Api.Domain.Resources.Holdings
{
    public record SavingsAccountHoldings(int Amount)
    {
        public SavingsAccountHoldings() : this(0) { }
    }
}
