using PensionGame.Api.Domain.Resources.Holdings.Values;

namespace PensionGame.Api.Common.Mappers.Holdings
{
    public interface IStockPriceMapper : IMapper<Core.Domain.Holdings.Values.StockPrice, StockPrice>, IMapper<StockPrice, Core.Domain.Holdings.Values.StockPrice>
    {
    }
}
