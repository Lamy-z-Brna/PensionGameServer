namespace PensionGame.Api.Common.Mappers.ClientData
{
    public sealed class InvestmentSelectionMapper : IInvestmentSelectionMapper
    {
        public Domain.Resources.ClientData.InvestmentSelection Map(Core.Domain.ClientData.InvestmentSelection investmentSelection)
        {
            return new(
                StockValue: investmentSelection.StockValue,
                BondValue: investmentSelection.BondValue,
                SavingsAccountValue: investmentSelection.SavingsAccountValue,
                LoanValue: investmentSelection.LoanValue
                );
        }

        public Core.Domain.ClientData.InvestmentSelection Map(Domain.Resources.ClientData.InvestmentSelection investmentSelection)
        {
            return new(
                StockValue: investmentSelection.StockValue,
                BondValue: investmentSelection.BondValue,
                SavingsAccountValue: investmentSelection.SavingsAccountValue,
                LoanValue: investmentSelection.LoanValue
                );
        }
    }
}
