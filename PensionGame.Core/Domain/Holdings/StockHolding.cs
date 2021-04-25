using PensionGame.Core.Common;
using PensionGame.Core.Domain.Holdings.Values;

namespace PensionGame.Core.Domain.Holdings
{
    public record StockHolding(StockPrice UnitPrice, double UnitsHeld)
    {
        public int Value => Rounder.Round(UnitPrice.Price * UnitsHeld);
    }
}
