using PensionGame.Core.Common;

namespace PensionGame.Api.Resources.Holdings
{
    public record StockHolding(double UnitPrice, double UnitsHeld)
    {
        public int StockValue => Rounder.Round(UnitPrice * UnitsHeld);
    }
}
