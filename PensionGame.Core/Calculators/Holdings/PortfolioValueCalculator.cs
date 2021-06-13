using PensionGame.Core.Calculators.RequiredData;
using PensionGame.Core.Domain.Holdings;

namespace PensionGame.Core.Calculators.Holdings
{
    public sealed class PortfolioValueCalculator : IPortfolioValueCalculator
    {
        public PortfolioValue Calculate(PortfolioValueRequiredData requiredData)
        {
            var gameState = requiredData.GameState;

            return new(gameState.ClientData.ClientHoldings.Value
                + gameState.ClientData.IncomeData.BondInterest
                + gameState.ClientData.IncomeData.SavingsAccountInterest
                - gameState.ClientData.ExpenseData.LoanExpenses);
        }
    }
}
