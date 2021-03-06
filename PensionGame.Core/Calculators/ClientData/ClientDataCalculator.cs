using PensionGame.Core.Calculators.Holdings;
using PensionGame.Core.Calculators.RequiredData;
using PensionGame.Core.Common;
using PensionGame.Core.Domain.ClientData;
using PensionGame.Core.Domain.Holdings;
using PensionGame.Core.Domain.Holdings.Values;
using PensionGame.Core.Events;
using PensionGame.Core.Events.Common;
using PensionGame.Core.Events.PreClientDataEvents;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PensionGame.Core.Calculators.ClientData
{
    public sealed class ClientDataCalculator : IClientDataCalculator
    {
        private readonly INewBondCalculator _newBondCalculator;
        private readonly INewSavingsAccountCalculator _newSavingsAccountCalculator;
        private readonly INewLoanCalculator _newLoanCalculator;

        public ClientDataCalculator(INewLoanCalculator newLoanCalculator,
            INewSavingsAccountCalculator newSavingsAccountCalculator,
            INewBondCalculator newBondCalculator)
        {
            _newLoanCalculator = newLoanCalculator;
            _newSavingsAccountCalculator = newSavingsAccountCalculator;
            _newBondCalculator = newBondCalculator;
        }

        public (Domain.ClientData.ClientData, IReadOnlyCollection<Event>) Calculate(ClientDataRequiredData requiredData)
        {
            var (previousClientData, previousMarketData, investmentSelection, marketData, events) = requiredData;
            var previousReturnData = previousMarketData.ReturnData;
            var (previousIncomeData, previousExpenseData, previousHoldings) = previousClientData;
            var (macroEconomicData, returnData) = marketData;

            var stockPrice = Math.Round(previousHoldings.Stocks.UnitPrice.Price * (1 + returnData.StockRate), 2);
            var stocksUnits = Math.Round(investmentSelection.StockValue / previousHoldings.Stocks.UnitPrice.Price, 2);
           
            var (bonds, bondEvents) = _newBondCalculator.Calculate
                (
                    new NewBondRequiredData
                    (
                        CurrentBonds: previousHoldings.Bonds,
                        InvestmentSelection: investmentSelection,
                        BondInterestRate: previousReturnData.BondRate,
                        BondDefaultRate: returnData.BondDefaultRate
                    )
                );

            var bondInterest = bonds.TotalPayments;

            var (newSavingsAccountHoldings, savingsAccountEvents) = _newSavingsAccountCalculator.Calculate
                (
                    new NewSavingsAccountRequiredData
                    (
                        CurrentClientData: previousClientData,
                        InvestmentSelection: investmentSelection
                    )
                );

            var savingsAccountInterest = Rounder.Round(newSavingsAccountHoldings.Amount * previousReturnData.SavingsAccountRate);
            
            var loans = _newLoanCalculator.Calculate
                (
                    new NewLoanRequiredData
                    (
                        CurrentLoans: previousHoldings.Loans,
                        InvestmentSelection: investmentSelection,
                        LoanInterestRate: previousReturnData.LoanRate
                    )
                );

            var loanInterest = loans
                .TotalInterestValue;

            var expectedSalary = Rounder.Round(previousIncomeData.ExpectedSalary * (1 + macroEconomicData.InflationRate));
            var unemploymentEvent = events.GetEvent<PreClientDataEvent, UnemploymentEvent>();
            var actualSalary = unemploymentEvent != null ? Rounder.Round(expectedSalary * (1 - unemploymentEvent.IncomeLoss)) : expectedSalary;

            var clientData = new Domain.ClientData.ClientData
                (
                    IncomeData: new IncomeData
                    (
                        ExpectedSalary: expectedSalary,
                        ActualSalary: actualSalary,
                        BondInterest: bondInterest,
                        SavingsAccountInterest: savingsAccountInterest,
                        ExtraIncome: 0
                    ),
                    ExpenseData: new ExpenseData
                    (
                        LifeExpenses: Rounder.Round(previousExpenseData.LifeExpenses * (1 + macroEconomicData.InflationRate)),
                        LoanExpenses: Rounder.Round(loanInterest),
                        ChildrenExpenses: 0,
                        ExtraExpenses: 0,
                        Rent: 0
                    ),
                    ClientHoldings: new ClientHoldings
                    (
                        Stocks: new StockHolding(new StockPrice(stockPrice), stocksUnits),
                        Bonds: new BondHoldings(bonds),
                        SavingsAccount: newSavingsAccountHoldings,
                        Loans: loans
                    )
                );

            return (clientData, savingsAccountEvents.Union(bondEvents).ToList());
        }
    }
}
