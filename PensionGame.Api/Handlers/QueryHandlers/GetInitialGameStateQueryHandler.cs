using PensionGame.Api.Domain.Resources.ClientData;
using PensionGame.Api.Domain.Resources.GameData;
using PensionGame.Api.Domain.Resources.Holdings;
using PensionGame.Api.Domain.Resources.MarketData;
using PensionGame.Api.Handlers.Queries;
using System.Threading.Tasks;

namespace PensionGame.Api.Handlers.QueryHandlers
{
    public sealed class GetInitialGameStateQueryHandler : IGetInitialGameStateQueryHandler
    {
        public async Task<GameState> Handle(GetInitialGameStateQuery query)
        {
            return new GameState
            (
                Year: 25,
                ClientData: new ClientData
                (
                    ClientHoldings: new ClientHoldings
                    (
                        Bonds: new BondHoldings(),
                        Loans: new LoanHoldings(),
                        SavingsAccount: new SavingsAccountHoldings(),
                        Stocks: new StockHolding()
                    ),
                    ExpenseData: new ExpenseData
                    {
                        ChildrenExpenses = 0,
                        ExtraExpenses = 0,
                        LifeExpenses = 100000,
                        Rent = 0
                    },
                    IncomeData: new IncomeData
                    {
                        BondInterest = 0,
                        ExtraIncome = 0,
                        Salary = 175000,
                        SavingsAccountInterest = 0
                    }
                ),
                MarketData: new MarketData
                (
                    new MacroEconomicData
                    (
                        IsCrisis: false,
                        InflationRate: 0.02,
                        UnemploymentRate: 0.06,
                        InterestRate: 0.02
                    ),
                    new ReturnData
                    (
                        StockRate: 0.06,
                        BondRate: 0.03,
                        BondDefaultRate: 0.02,
                        SavingsAccountRate: 0.01,
                        LoanRate: 0.09
                    )
                ),
                IsInitial: true,
                IsFinished: false
            );
        }
    }
}
