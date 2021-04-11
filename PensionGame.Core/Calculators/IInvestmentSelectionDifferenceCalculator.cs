using PensionGame.Core.Calculators.Common;
using PensionGame.Core.Calculators.RequiredData;

namespace PensionGame.Core.Calculators
{
    public interface IInvestmentSelectionDifferenceCalculator : ICalculator<InvestmentSelectionDifferenceRequiredData, (int StockChange, int BondChange, int SavingsAccountChange, int LoanChange)>
    {
    }
}
