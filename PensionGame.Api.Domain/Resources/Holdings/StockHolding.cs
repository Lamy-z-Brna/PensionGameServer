using PensionGame.Api.Domain.Resources.Holdings.Values;
using System;

namespace PensionGame.Api.Domain.Resources.Holdings
{
    public record StockHolding(StockPrice UnitPrice, double UnitsHeld)
    {
        public StockHolding() : this(new StockPrice(1), 0) { }

        public int Value => (int)Math.Round(UnitPrice.Price * UnitsHeld, 0);
    }
}
