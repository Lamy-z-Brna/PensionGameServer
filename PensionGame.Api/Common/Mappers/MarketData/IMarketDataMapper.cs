namespace PensionGame.Api.Common.Mappers.MarketData
{
    public interface IMarketDataMapper : IMapper<Core.Domain.MarketData.MarketData, Domain.Resources.MarketData.MarketData>, IMapper<Domain.Resources.MarketData.MarketData, Core.Domain.MarketData.MarketData>
    {
    }
}
