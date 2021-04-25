namespace PensionGame.Api.Domain.Resources.Holdings
{
    public record BondHolding(int YearlyPayment, int YearsToExpiration)
    {
        public int Value => YearlyPayment * YearsToExpiration;
    }
}
