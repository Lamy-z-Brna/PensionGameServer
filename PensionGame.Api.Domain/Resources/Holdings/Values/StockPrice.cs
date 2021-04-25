using System;

namespace PensionGame.Api.Domain.Resources.Holdings.Values
{
    public record StockPrice
    {
        public double Price { get; }

        public StockPrice(double price)
        {
            Price = Math.Round(price, 2);
        }
    }
}
