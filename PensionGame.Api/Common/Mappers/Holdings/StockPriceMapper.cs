namespace PensionGame.Api.Common.Mappers.Holdings
{
    public sealed class StockPriceMapper : IStockPriceMapper
    {
        public Domain.Resources.Holdings.Values.StockPrice Map(Core.Domain.Holdings.Values.StockPrice stockPrice)
        {
            return new(stockPrice.Price);
        }

        public Core.Domain.Holdings.Values.StockPrice Map(Domain.Resources.Holdings.Values.StockPrice stockPrice)
        {
            return new(stockPrice.Price);
        }
    }
}
