using PensionGame.Api.Handlers.Queries;
using PensionGame.Api.Resources.ClientData;
using PensionGame.Api.Resources.Events;
using PensionGame.Api.Resources.GameData;
using PensionGame.Api.Resources.Holdings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                        Bonds: new List<BondHolding>
                        {
                            new BondHolding(1000, 5),
                            new BondHolding(700, 3)
                        },
                        Loans: Enumerable.Empty<LoanHolding>(),
                        SavingsAccount: new SavingsAccountHoldings(26),
                        Stocks: new StockHolding(35, 102)
                    ),
                    Events: Enumerable.Empty<Event>(),
                    ExpenseData: new ExpenseData
                    {
                        ChildrenExpenses = 0,
                        ExtraExpenses = 0,
                        LifeExpenses = 10000,
                        Rent = 1520
                    },
                    IncomeData: new IncomeData
                    {
                        BondInterest = 0,
                        ExtraIncome = 10000,
                        Salary = 15000,
                        SavingsAccountInterest = 10
                    }
                ),
                IsFinished: false
            );
        }
    }
}
