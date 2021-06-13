namespace PensionGame.Core.Domain.Holdings
{
    public record BondHolding(int YearlyPayment, int YearsToExpiration)
    {
        public int Value => YearlyPayment * YearsToExpiration;
    }
}
