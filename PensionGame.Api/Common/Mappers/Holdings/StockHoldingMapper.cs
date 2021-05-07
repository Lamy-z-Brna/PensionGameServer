namespace PensionGame.Api.Common.Mappers.Holdings
{
    public sealed class StockHoldingMapper : IStockHoldingMapper
    {
        private readonly IStockPriceMapper _stockPriceMapper;

        public StockHoldingMapper(IStockPriceMapper stockPriceMapper)
        {
            _stockPriceMapper = stockPriceMapper;
        }

        public Domain.Resources.Holdings.StockHolding Map(Core.Domain.Holdings.StockHolding stockHolding)
        {
            return new(
                UnitPrice: _stockPriceMapper.Map(stockHolding.UnitPrice),
                UnitsHeld: stockHolding.UnitsHeld
                );
        }

        public Core.Domain.Holdings.StockHolding Map(Domain.Resources.Holdings.StockHolding stockHolding)
        {
            return new(
                UnitPrice: _stockPriceMapper.Map(stockHolding.UnitPrice),
                UnitsHeld: stockHolding.UnitsHeld
                );
        }
    }
}
