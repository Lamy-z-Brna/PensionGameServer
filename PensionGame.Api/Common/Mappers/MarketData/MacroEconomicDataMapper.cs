namespace PensionGame.Api.Common.Mappers.MarketData
{
    public sealed class MacroEconomicDataMapper : IMacroEconomicDataMapper
    {
        public Domain.Resources.MarketData.MacroEconomicData Map(Core.Domain.MarketData.MacroEconomicData macroEconomicData)
        {
            return new (
                InflationRate: macroEconomicData.InflationRate, 
                UnemploymentRate: macroEconomicData.UnemploymentRate, 
                InterestRate: macroEconomicData.InterestRate
                );
        }

        public Core.Domain.MarketData.MacroEconomicData Map(Domain.Resources.MarketData.MacroEconomicData macroEconomicData)
        {
            return new(
                InflationRate: macroEconomicData.InflationRate,
                UnemploymentRate: macroEconomicData.UnemploymentRate,
                InterestRate: macroEconomicData.InterestRate
                );
        }
    }
}
