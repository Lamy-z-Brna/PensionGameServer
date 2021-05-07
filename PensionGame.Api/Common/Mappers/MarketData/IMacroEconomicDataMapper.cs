using PensionGame.Api.Domain.Resources.MarketData;

namespace PensionGame.Api.Common.Mappers.MarketData
{
    public interface IMacroEconomicDataMapper : IMapper<Core.Domain.MarketData.MacroEconomicData, MacroEconomicData>, IMapper<MacroEconomicData, Core.Domain.MarketData.MacroEconomicData>
    {
    }
}
