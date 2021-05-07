using PensionGame.Api.Domain.Resources.ClientData;

namespace PensionGame.Web.Data
{
    public sealed class InvestmentSelectionModel
    {
        public int StockValue { get; set; }

        public int BondValue { get; set; }

        public int SavingsAccountValue { get; set; }

        public int LoanValue { get; set; }

        public InvestmentSelectionModel(InvestmentSelection investmentSelection)
        {
            (StockValue, BondValue, SavingsAccountValue, LoanValue) = investmentSelection;
        }

        public static implicit operator InvestmentSelection(InvestmentSelectionModel model)
        {
            return new(
                StockValue: model.StockValue,
                BondValue: model.BondValue,
                SavingsAccountValue: model.SavingsAccountValue,
                LoanValue: model.LoanValue
            );
        }
    }
}