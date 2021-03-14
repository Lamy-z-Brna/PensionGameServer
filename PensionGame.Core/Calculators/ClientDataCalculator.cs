using PensionGame.Core.Calculators.RequiredData;
using PensionGame.Core.Common;
using PensionGame.Core.Domain.ClientData;
using PensionGame.Core.Domain.Holdings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionGame.Core.Calculators
{
    public sealed class ClientDataCalculator : IClientDataCalculator
    {
        public ClientData Calculate(ClientDataRequiredData requiredData)
        {
            var previousClientData = requiredData.PreviousClientData;
            var previousIncomeData = previousClientData.IncomeData;
            var previousExpenseData = previousClientData.ExpenseData;
            var previousHoldings = previousClientData.ClientHoldings;

            var macroEconomicData = requiredData.MacroEconomicData;
            var investmentSelection = requiredData.InvestmentSelection;
            var returnData = requiredData.ReturnData;

            var stockPrice = Math.Round(previousHoldings.Stocks.UnitPrice * returnData.StockRate, 2);
            var stocksUnits = Math.Round(investmentSelection.StockValue / previousHoldings.Stocks.UnitPrice, 2);

            var bondInterest = previousHoldings.Bonds
                .Sum(bond => bond.YearlyPayment);

            var bonds = previousHoldings.Bonds
                .Select(bond => bond with { YearsToExpiration = bond.YearsToExpiration - 1 })
                .Where(bond => bond.YearsToExpiration > 0)
                .ToList();

            bonds.Add(new BondHolding(Rounder.Round(investmentSelection.BondValue * (1 + returnData.BondRate)), 10));

            var loanInterest = previousHoldings.Loans
                .Sum(loans => loans.Amount * loans.InterestRate);

            var loanAmount = investmentSelection.LoanValue - previousHoldings.TotalLoanValue;

            var loans = previousHoldings.Loans
                .ToList();

            loans.Add(new LoanHolding(loanAmount, returnData.LoanRate));

            var clientData = new ClientData
                (
                    IncomeData: new IncomeData
                    (
                        Salary: Rounder.Round(previousIncomeData.Salary * macroEconomicData.InflationRate),
                        BondInterest: bondInterest,
                        SavingsAccountInterest: Rounder.Round(investmentSelection.SavingsAccountValue * returnData.SavingsAccountRate),
                        ExtraIncome: 0
                    ),
                    ExpenseData: new ExpenseData
                    (
                        LifeExpenses: Rounder.Round(previousExpenseData.LifeExpenses * macroEconomicData.InflationRate),
                        LoanInterest: Rounder.Round(loanInterest),
                        ChildrenExpenses: 0,
                        ExtraExpenses: 0,
                        Rent: 0
                    ),
                    ClientHoldings: new ClientHoldings
                    (
                        Stocks: new StockHolding(stockPrice, stocksUnits),
                        Bonds: bonds,
                        SavingsAccount: new SavingsAccountHoldings(investmentSelection.SavingsAccountValue),
                        Loans: loans
                    )
                );

            return clientData;
        }
    }
}
