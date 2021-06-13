using PensionGame.Api.Common.Mappers.GameState;
using PensionGame.Api.Handlers.Queries;
using PensionGame.Core.Domain.GameData;
using PensionGame.Core.Domain.Holdings;
using PensionGame.Core.Events.Common;
using System;
using System.Threading.Tasks;

namespace PensionGame.Api.Handlers.QueryHandlers
{
    public sealed class GetInitialGameStateQueryHandler : IGetInitialGameStateQueryHandler
    {
        private readonly IGameStateMapper _gameStateMapper;

        public GetInitialGameStateQueryHandler(IGameStateMapper gameStateMapper)
        {
            _gameStateMapper = gameStateMapper;
        }

        public async Task<GameState> Handle(GetInitialCoreGameStateQuery query)
        {
            var (income, expenses, year, retirementYear, existingFunds) = query.StartupParameters ?? new (175000, 100000, 25, 65, 100000);

            var gameState = new GameState
            (
                Year: year,
                RetirementYear: retirementYear,
                ClientData: new(
                    ClientHoldings: new
                    (
                        Bonds: new(Array.Empty<BondHolding>()),
                        Loans: new(Array.Empty<LoanHolding>()),
                        SavingsAccount: new(0),
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
                        ExtraIncome: existingFunds,
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

        public async Task<Domain.Resources.GameData.GameState> Handle(GetInitialGameStateQuery query)
        {
            var result = await Handle(new GetInitialCoreGameStateQuery(query.StartupParameters));

            return _gameStateMapper.Map(result);
        }
    }
}
