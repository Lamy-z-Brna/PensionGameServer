using AutoMapper;
using PensionGame.Api.Handlers.Commands;
using PensionGame.Api.Resources.ClientData;
using PensionGame.Api.Resources.Events;
using PensionGame.Api.Resources.GameData;
using PensionGame.Api.Resources.Holdings;
using PensionGame.Core.Calculators;
using PensionGame.Core.Calculators.RequiredData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PensionGame.Api.Handlers.CommandHandlers
{
    public sealed class CheckInvestmentSelectionCommandHandler : ICheckInvestmentSelectionCommandHandler
    {
        private readonly IInvestmentSelectionValidationCalculator _investmentSelectionValidationCalculator;
        private readonly IMapper _mapper;

        public CheckInvestmentSelectionCommandHandler(IInvestmentSelectionValidationCalculator investmentSelectionValidationCalculator,
            IMapper mapper)
        {
            _investmentSelectionValidationCalculator = investmentSelectionValidationCalculator;
            _mapper = mapper;
        }

        public async Task Handle(CheckInvestmentSelectionCommand command)
        {
            var gameState = new GameState
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

            var clientData = _mapper.Map<Core.Domain.ClientData.ClientData>(gameState.ClientData);
            var investmentSelection = _mapper.Map<Core.Domain.ClientData.InvestmentSelection>(command.InvestmentSelection);

            var result = _investmentSelectionValidationCalculator.Calculate
                (
                    new InvestmentSelectionValidationRequiredData
                    (
                        CurrentClientData: clientData,
                        InvestmentSelection: investmentSelection
                    )
                );

            result.OnError(error => throw new Exception(string.Join(",", error.ErrorMessages)));
        }
    }
}
