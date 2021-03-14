using PensionGame.Core.Common;

namespace PensionGame.Core.Domain.Holdings
{
    public record StockHolding(double UnitPrice, double UnitsHeld)
    {
        public int Value => Rounder.Round(UnitPrice * UnitsHeld);
    }
}
