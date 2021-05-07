using PensionGame.Api.Domain.Resources.Events;
using PensionGame.Api.Domain.Resources.GameData;
using PensionGame.Api.Handlers.Queries;
using System;
using System.Threading.Tasks;

namespace PensionGame.Api.Handlers.QueryHandlers
{
    public sealed class GetInitialGameStateQueryHandler : IGetInitialGameStateQueryHandler
    {
        public async Task<GameState> Handle(GetInitialGameStateQuery query)
        {
            var (income, expenses, year, retirementYear) = query.StartupParameters ?? new (175000, 100000, 25, 65);

            var gameState = new GameState
            (
                Year: year,
                RetirementYear: retirementYear,
                ClientData: new(
                    ClientHoldings: new
                    (
                        Bonds: new(),
                        Loans: new(),
                        SavingsAccount: new(),
                        Stocks: new(new(1), 0)
                    ),
                    ExpenseData: new(
                        ChildrenExpenses: 0,
                        ExtraExpenses: 0,
                        LifeExpenses: expenses,
                        Rent: 0,
                        LoanExpenses: 0
                    ),
                    IncomeData: new(
                        BondInterest: 0,
                        ExtraIncome: 0,
                        ExpectedSalary: income,
                        ActualSalary: income,
                        SavingsAccountInterest: 0
                    )
                ),
                MarketData: new
                (
                    new
                    (
                        InflationRate: 0,
                        UnemploymentRate: 0.06,
                        InterestRate: 0.02
                    ),
                    new
                    (
                        StockRate: 0,
                        BondRate: 0.03,
                        BondDefaultRate: 0.005,
                        SavingsAccountRate: 0.01,
                        LoanRate: 0.12
                    )
                ),
                IsInitial: true,
                Events: Array.Empty<Event>()
            );

            return await Task.FromResult(gameState);
        }
    }
}
