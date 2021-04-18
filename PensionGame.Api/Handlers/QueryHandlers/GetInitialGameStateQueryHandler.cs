using PensionGame.Api.Domain.Resources.ClientData;
using PensionGame.Api.Domain.Resources.Events;
using PensionGame.Api.Domain.Resources.GameData;
using PensionGame.Api.Domain.Resources.Holdings;
using PensionGame.Api.Domain.Resources.MarketData;
using PensionGame.Api.Domain.Resources.Session;
using PensionGame.Api.Handlers.Queries;
using System;
using System.Threading.Tasks;

namespace PensionGame.Api.Handlers.QueryHandlers
{
    public sealed class GetInitialGameStateQueryHandler : IGetInitialGameStateQueryHandler
    {
        public async Task<GameState> Handle(GetInitialGameStateQuery query)
        {
            var (income, expenses, year, retirementYear) = query.StartupParameters ?? new StartupParameters(175000, 100000, 25, 65);

            var gameState = new GameState
            (
                Year: year,
                RetirementYear: retirementYear,
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
                        LifeExpenses = expenses,
                        Rent = 0
                    },
                    IncomeData: new IncomeData
                    {
                        BondInterest = 0,
                        ExtraIncome = 0,
                        ExpectedSalary = income,
                        ActualSalary = income,
                        SavingsAccountInterest = 0
                    }
                ),
                MarketData: new MarketData
                (
                    new MacroEconomicData
                    (
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
                Events: Array.Empty<Event>()
            );

            return await Task.FromResult(gameState);
        }
    }
}
