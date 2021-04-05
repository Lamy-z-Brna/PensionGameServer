using PensionGame.Core.Calculators.RequiredData;
using PensionGame.Core.Common;
using PensionGame.Core.Domain.ClientData;
using PensionGame.Core.Domain.Holdings;
using PensionGame.Core.Events;
using PensionGame.Core.Events.Common;
using System;
using System.Linq;

namespace PensionGame.Core.Calculators
{
    public sealed class ClientDataCalculator : IClientDataCalculator
    {
        private readonly INewBondCalculator _newBondCalculator;
        private readonly INewLoanCalculator _newLoanCalculator;

        public ClientDataCalculator(INewLoanCalculator newLoanCalculator,
            INewBondCalculator newBondCalculator)
        {
            _newLoanCalculator = newLoanCalculator;
            _newBondCalculator = newBondCalculator;
        }

        public ClientData Calculate(ClientDataRequiredData requiredData)
        {
            var (previousClientData, previousMarketData, investmentSelection, marketData, events) = requiredData;
            var previousReturnData = previousMarketData.ReturnData;
            var (previousIncomeData, previousExpenseData, previousHoldings) = previousClientData;
            var (macroEconomicData, returnData) = marketData;

            var stockPrice = Math.Round(previousHoldings.Stocks.UnitPrice * (1 + returnData.StockRate), 2);
            var stocksUnits = Math.Round(investmentSelection.StockValue / previousHoldings.Stocks.UnitPrice, 2);

            var bondInterest = previousHoldings.Bonds.TotalPayments;

            var bonds = _newBondCalculator.Calculate
                (
                    new NewBondRequiredData
                    (
                        CurrentBonds: previousHoldings.Bonds,
                        InvestmentSelection: investmentSelection,
                        BondInterestRate: previousReturnData.BondRate,
                        BondDefaultRate: returnData.BondDefaultRate
                    )
                );

            var loanInterest = previousHoldings.Loans
                .Sum(loans => loans.Amount * loans.InterestRate);

            var loanAmount = investmentSelection.LoanValue - previousHoldings.TotalLoanValue;

            var loans = _newLoanCalculator.Calculate
                (
                    new NewLoanRequiredData
                    (
                        CurrentLoans: previousHoldings.Loans,
                        InvestmentSelection: investmentSelection,
                        LoanInterestRate: previousReturnData.LoanRate
                    )
                );

            var expectedSalary = Rounder.Round(previousIncomeData.ExpectedSalary * (1 + macroEconomicData.InflationRate));
            var unemploymentEvent = events.GetEvent<UnemploymentEvent>();
            var actualSalary = unemploymentEvent != null ? Rounder.Round(expectedSalary * (1 - unemploymentEvent.IncomeLoss)) : expectedSalary;

            var clientData = new ClientData
                (
                    IncomeData: new IncomeData
                    (
                        ExpectedSalary: expectedSalary,
                        ActualSalary: actualSalary,
                        BondInterest: bondInterest,
                        SavingsAccountInterest: Rounder.Round(investmentSelection.SavingsAccountValue * previousReturnData.SavingsAccountRate),
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
                        Stocks: new StockHolding(stockPrice, stocksUnits),
                        Bonds: new BondHoldings(bonds),
                        SavingsAccount: new SavingsAccountHoldings(investmentSelection.SavingsAccountValue),
                        Loans: loans
                    )
                );

            return clientData;
        }
    }
}
