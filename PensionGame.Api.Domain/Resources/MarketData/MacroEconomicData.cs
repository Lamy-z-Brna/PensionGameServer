namespace PensionGame.Api.Domain.Resources.MarketData
{
    public record MacroEconomicData(bool IsCrisis, double InflationRate, double UnemploymentRate, double InterestRate)
    {
    }
}
