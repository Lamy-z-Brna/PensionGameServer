namespace PensionGame.Api.Domain.Resources.Holdings
{
    public record StockHolding(double UnitPrice, double UnitsHeld)
    {
        public StockHolding() : this(1, 0) { }
    }
}
