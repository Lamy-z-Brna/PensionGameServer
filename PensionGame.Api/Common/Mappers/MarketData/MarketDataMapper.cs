namespace PensionGame.Api.Common.Mappers.MarketData
{
    public sealed class MarketDataMapper : IMarketDataMapper
    {
        private readonly IMacroEconomicDataMapper _macroEconomicDataMapper;
        private readonly IReturnDataMapper _returnDataMapper;

        public MarketDataMapper(IMacroEconomicDataMapper macroEconomicDataMapper, 
            IReturnDataMapper returnDataMapper)
        {
            _macroEconomicDataMapper = macroEconomicDataMapper;
            _returnDataMapper = returnDataMapper;
        }

        public Domain.Resources.MarketData.MarketData Map(Core.Domain.MarketData.MarketData marketData)
        {
            return new(
                MacroEconomicData: _macroEconomicDataMapper.Map(marketData.MacroEconomicData),
                ReturnData: _returnDataMapper.Map(marketData.ReturnData)
                );
        }

        public Core.Domain.MarketData.MarketData Map(Domain.Resources.MarketData.MarketData marketData)
        {
            return new(
                MacroEconomicData: _macroEconomicDataMapper.Map(marketData.MacroEconomicData),
                ReturnData: _returnDataMapper.Map(marketData.ReturnData)
                );
        }
    }
}
