using PensionGame.Api.Handlers.Queries;
using PensionGame.Api.Domain.Resources.ClientData;
using PensionGame.Api.Domain.Resources.Events;
using PensionGame.Api.Domain.Resources.GameData;
using PensionGame.Api.Domain.Resources.Holdings;
using System.Linq;
using System.Threading.Tasks;
using PensionGame.Api.Domain.Resources.MarketData;

namespace PensionGame.Api.Handlers.QueryHandlers
{
    public sealed class GetGameStateQueryHandler : IGetGameStateQueryHandler
    {
        public async Task<GameState> Handle(GetGameStateQuery query)
        {
            return new GameState
            (
                Year: 26,
                ClientData: new ClientData
                (
                    ClientHoldings: new ClientHoldings
                    (
                        Bonds: new BondHoldings(new []
                        {
                            new BondHolding(1000, 5),
                            new BondHolding(700, 3)
                        }),
                        Loans: new LoanHoldings(new[]
                        {
                            new LoanHolding(1000, 0.05),
                            new LoanHolding(700, 0.1),
                            new LoanHolding(400, 0.45)
                        }),
                        SavingsAccount: new SavingsAccountHoldings(26),
                        Stocks: new StockHolding(35, 102)
                    ),
                    ExpenseData: new ExpenseData
                    {
                        ChildrenExpenses = 0,
                        ExtraExpenses = 0,
                        LifeExpenses = 10000,
                        Rent = 0
                    },
                    IncomeData: new IncomeData
                    {
                        BondInterest = 0,
                        ExtraIncome = 0,
                        Salary = 17500,
                        SavingsAccountInterest = 10
                    }
                ),
                MarketData: new MarketData
                (
                    new MacroEconomicData
                    (
                        IsCrisis: false,
                        InflationRate: 0.03,
                        UnemploymentRate: 0.07,
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
                IsFinished: false
            );
        }
    }
}
