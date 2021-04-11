using System;

namespace PensionGame.Api.Domain.Resources.Holdings
{
    public record StockHolding(double UnitPrice, double UnitsHeld)
    {
        public StockHolding() : this(1, 0) { }

        public int Value => (int)Math.Round(UnitPrice * UnitsHeld, 0);
    }
}
