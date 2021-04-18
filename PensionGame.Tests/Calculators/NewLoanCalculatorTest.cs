using NUnit.Framework;
using PensionGame.Core.Calculators.Holdings;
using PensionGame.Core.Calculators.RequiredData;
using PensionGame.Core.Domain.ClientData;
using PensionGame.Core.Domain.Holdings;
using System.Linq;

namespace PensionGame.Tests.Calculators
{
    public sealed class NewLoanCalculatorTest
    {
        private INewLoanCalculator UnderTest { get; }

        public NewLoanCalculatorTest()
        {
            UnderTest = new NewLoanCalculator();
        }

        [Test]
        public void WhenNewLoanRequired_NewLoanIsCreated()
        {
            var currentLoans = new LoanHoldings(new[] { new LoanHolding(2000, 0.07), new LoanHolding(3000, 0.06) });
            var currentLoanValue = currentLoans.TotalLoanValue;
            var newLoanValue = 4000;
            var newLoanRate = 0.09;

            var newLoanRequiredData = new NewLoanRequiredData
                (
                    CurrentLoans: currentLoans,
                    InvestmentSelection: new InvestmentSelection
                    (
                        0, 0, 6000, currentLoanValue + newLoanValue
                    ),
                    newLoanRate
                );

            var result = UnderTest.Calculate(newLoanRequiredData);

            var expectedLoanHoldings = new LoanHoldings
                (
                    new[]
                    {
                        new LoanHolding(2000, 0.07),
                        new LoanHolding(3000, 0.06),
                        new LoanHolding(newLoanValue, newLoanRate)
                    }
                );

            Assert.AreEqual(expectedLoanHoldings, result);
        }

        [Test]
        public void WhenNoNewLoanIsRequired_NoNewLoanIsCreated()
        {
            var currentLoans = new LoanHoldings(new[] { new LoanHolding(2000, 0.07), new LoanHolding(3000, 0.06) });
            var currentLoanValue = currentLoans.TotalLoanValue;
            var newLoanValue = 0;
            var newLoanRate = 0.09;

            var newLoanRequiredData = new NewLoanRequiredData
                (
                    CurrentLoans: currentLoans,
                    InvestmentSelection: new InvestmentSelection
                    (
                        0, 0, 6000, currentLoanValue + newLoanValue
                    ),
                    newLoanRate
                );

            var result = UnderTest.Calculate(newLoanRequiredData);

            var expectedLoanHoldings = new LoanHoldings
                (
                    new[]
                    {
                        new LoanHolding(2000, 0.07),
                        new LoanHolding(3000, 0.06),
                    }
                );

            Assert.AreEqual(expectedLoanHoldings, result);
        }

        [Test]
        public void WhenPartialRepaymentIsRequired_LoanIsPartiallyRepaid()
        {
            var currentLoans = new LoanHoldings(new[] { new LoanHolding(2000, 0.07), new LoanHolding(3000, 0.06) });
            var currentLoanValue = currentLoans.TotalLoanValue;
            var newLoanValue = -1000;
            var newLoanRate = 0.09;

            var newLoanRequiredData = new NewLoanRequiredData
                (
                    CurrentLoans: currentLoans,
                    InvestmentSelection: new InvestmentSelection
                    (
                        0, 0, 6000, currentLoanValue + newLoanValue
                    ),
                    newLoanRate
                );

            var result = UnderTest.Calculate(newLoanRequiredData);

            var expectedLoanHoldings = new LoanHoldings
                (
                    new[]
                    {
                        new LoanHolding(1000, 0.07),
                        new LoanHolding(3000, 0.06),
                    }
                );

            Assert.AreEqual(expectedLoanHoldings, result);
        }

        [Test]
        public void WhenFullRepaymentIsRequired_LoanIsFullyRepaid()
        {
            var currentLoans = new LoanHoldings(new[] { new LoanHolding(2000, 0.07), new LoanHolding(4000, 0.06) });
            var currentLoanValue = currentLoans.TotalLoanValue;
            var newLoanValue = -2500;
            var newLoanRate = 0.09;

            var newLoanRequiredData = new NewLoanRequiredData
                (
                    CurrentLoans: currentLoans,
                    InvestmentSelection: new InvestmentSelection
                    (
                        0, 0, 6000, currentLoanValue + newLoanValue
                    ),
                    newLoanRate
                );

            var result = UnderTest.Calculate(newLoanRequiredData);

            var expectedLoanHoldings = new LoanHoldings
                (
                    new[]
                    {
                        new LoanHolding(3500, 0.06),
                    }
                );

            Assert.AreEqual(expectedLoanHoldings, result);
        }

        [Test]
        public void WhenNewLoanRequired_OldLoansAreRefinanced()
        {
            var loanAmount1 = 2000;
            var loanAmount2 = 3000;
            var currentLoans = new LoanHoldings(new[] { new LoanHolding(loanAmount1, 0.07), new LoanHolding(loanAmount2, 0.06) });
            var currentLoanValue = currentLoans.TotalLoanValue;
            var newLoanValue = 4000;
            var newLoanRate = 0.05;

            var newLoanRequiredData = new NewLoanRequiredData
                (
                    CurrentLoans: currentLoans,
                    InvestmentSelection: new InvestmentSelection
                    (
                        0, 0, 6000, currentLoanValue + newLoanValue
                    ),
                    newLoanRate
                );

            var result = UnderTest.Calculate(newLoanRequiredData);

            var expectedLoanHoldings = new LoanHoldings
                (
                    new[]
                    {
                        new LoanHolding(newLoanValue + loanAmount1 + loanAmount2, newLoanRate)
                    }
                );

            Assert.AreEqual(expectedLoanHoldings, result);
        }

        [Test]
        public void WhenNoNewLoanRequired_OldLoansAreRefinanced()
        {
            var loanAmount1 = 2000;
            var loanAmount2 = 3000;
            var currentLoans = new LoanHoldings(new[] { new LoanHolding(loanAmount1, 0.07), new LoanHolding(loanAmount2, 0.06) });
            var currentLoanValue = currentLoans.TotalLoanValue;
            var newLoanValue = 0;
            var newLoanRate = 0.065;

            var newLoanRequiredData = new NewLoanRequiredData
                (
                    CurrentLoans: currentLoans,
                    InvestmentSelection: new InvestmentSelection
                    (
                        0, 0, 6000, currentLoanValue + newLoanValue
                    ),
                    newLoanRate
                );

            var result = UnderTest.Calculate(newLoanRequiredData)
                .OrderBy(loan => loan.Amount);

            var expectedLoanHoldings = new LoanHoldings
                (
                    new[]
                    {
                        new LoanHolding(newLoanValue + loanAmount1, newLoanRate),
                        new LoanHolding(loanAmount2, 0.06)
                    }
                );

            Assert.AreEqual(expectedLoanHoldings, result);
        }

        [Test]
        public void WhenPartialRepaymentIsRequired_OldLoansAreRefinanced()
        {
            var loanAmount1 = 2000;
            var loanAmount2 = 3000;
            var currentLoans = new LoanHoldings(new[] { new LoanHolding(loanAmount1, 0.07), new LoanHolding(loanAmount2, 0.06) });
            var currentLoanValue = currentLoans.TotalLoanValue;
            var newLoanValue = -1000;
            var newLoanRate = 0.06;

            var newLoanRequiredData = new NewLoanRequiredData
                (
                    CurrentLoans: currentLoans,
                    InvestmentSelection: new InvestmentSelection
                    (
                        0, 0, 6000, currentLoanValue + newLoanValue
                    ),
                    newLoanRate
                );

            var result = UnderTest.Calculate(newLoanRequiredData);

            var expectedLoanHoldings = new LoanHoldings
                (
                    new[]
                    {
                        new LoanHolding(loanAmount1 + loanAmount2 + newLoanValue, 0.06),
                    }
                );

            Assert.AreEqual(expectedLoanHoldings, result);
        }
    }
}
