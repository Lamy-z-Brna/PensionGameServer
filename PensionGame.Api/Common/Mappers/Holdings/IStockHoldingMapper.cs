using PensionGame.Api.Domain.Resources.Holdings;

namespace PensionGame.Api.Common.Mappers.Holdings
{
    public interface IStockHoldingMapper : IMapper<Core.Domain.Holdings.StockHolding, StockHolding>, IMapper<StockHolding, Core.Domain.Holdings.StockHolding>
    {
    }
}
