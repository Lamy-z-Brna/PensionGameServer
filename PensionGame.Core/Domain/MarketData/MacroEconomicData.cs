namespace PensionGame.Core.Domain.MarketData
{
    public record MacroEconomicData(bool IsCrisis, double InflationRate, double UnemploymentRate, double InterestRate)
    {
    }
}
