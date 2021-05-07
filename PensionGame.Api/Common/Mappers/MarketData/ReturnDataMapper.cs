namespace PensionGame.Api.Common.Mappers.MarketData
{
    public sealed class ReturnDataMapper : IReturnDataMapper
    {
        public Domain.Resources.MarketData.ReturnData Map(Core.Domain.MarketData.ReturnData returnData)
        {
            return new (
                StockRate: returnData.StockRate, 
                BondRate: returnData.BondRate, 
                BondDefaultRate: returnData.BondDefaultRate, 
                SavingsAccountRate: returnData.SavingsAccountRate, 
                LoanRate: returnData.LoanRate
                );
        }

        public Core.Domain.MarketData.ReturnData Map(Domain.Resources.MarketData.ReturnData returnData)
        {
            return new(
                StockRate: returnData.StockRate,
                BondRate: returnData.BondRate,
                BondDefaultRate: returnData.BondDefaultRate,
                SavingsAccountRate: returnData.SavingsAccountRate,
                LoanRate: returnData.LoanRate
                );
        }
    }
}
