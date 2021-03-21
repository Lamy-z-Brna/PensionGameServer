using PensionGame.Api.Domain.Resources.ClientData;

namespace PensionGame.Web.Data
{
    public class InvestmentSelectionModel
    {
        public InvestmentSelectionModel(InvestmentSelection investmentSelection)
        {
            StockValue = investmentSelection.StockValue;
            BondValue = investmentSelection.BondValue;
            SavingsAccountValue = investmentSelection.SavingsAccountValue;
            LoanValue = investmentSelection.LoanValue;
        }

        public static implicit operator InvestmentSelection(InvestmentSelectionModel model)
        {
            return new()
            {
                StockValue = model.StockValue,
                BondValue = model.BondValue,
                SavingsAccountValue = model.SavingsAccountValue,
                LoanValue = model.LoanValue
            };
        }

        public int StockValue { get; set; }

        public int BondValue { get; set; }

        public int SavingsAccountValue { get; set; }

        public int LoanValue { get; set; }
    }
}