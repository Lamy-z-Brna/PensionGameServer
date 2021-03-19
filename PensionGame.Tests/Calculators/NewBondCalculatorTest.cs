using Moq;
using NUnit.Framework;
using PensionGame.Core.Calculators;
using PensionGame.Core.Calculators.Parameters;
using PensionGame.Core.Calculators.RequiredData;
using PensionGame.Core.Domain.ClientData;
using PensionGame.Core.Domain.Holdings;
using System.Linq;

namespace PensionGame.Tests.Calculators
{
    public sealed class NewBondCalculatorTest
    {
        private static int BondDefaultMaturity = 10;

        private INewBondCalculator UnderTest { get; }

        public NewBondCalculatorTest()
        {
            var mockedBondParameters = new Mock<INewBondParameters>();
            mockedBondParameters
                .SetupGet(x => x.DefaultMaturity).Returns(BondDefaultMaturity);

            var mockedBondPaymentCalculator = new Mock<IBondPaymentCalculator>();
            mockedBondPaymentCalculator
                .Setup(x => x.Calculate(It.IsAny<BondPaymentRequiredData>()))
                .Returns<BondPaymentRequiredData>(required => required.Price);

            UnderTest = new NewBondCalculator(mockedBondParameters.Object, mockedBondPaymentCalculator.Object);
        }


        [Test]
        public void BreakingTest()
        {
            Assert.AreEqual(2+2, 2);
        }

        [Test]
        public void MaturityIsDecreasedByOneYear()
        {
            var requiredData = new NewBondRequiredData
                (
                    CurrentBonds: new BondHoldings
                    (
                        new[] { new BondHolding(2500, 12), new BondHolding(3000, 6) }
                    ),
                    InvestmentSelection: new InvestmentSelection
                    (
                        3000, 0, 800, 3200
                    ),
                    BondInterestRate: 0.03,
                    BondDefaultRate: 0.07
                );

            var result = UnderTest.Calculate(requiredData);
            var expirationYears = result
                .Select(bond => bond.YearsToExpiration)
                .ToArray();

            Assert.AreEqual(new[] { 11, 5 }, expirationYears);
        }

        [Test]
        public void PaymentsWithOneYearLeftExpire()
        {
            var requiredData = new NewBondRequiredData
                (
                    CurrentBonds: new BondHoldings
                    (
                        new[] { new BondHolding(2500, 12), new BondHolding(3000, 1) }
                    ),
                    InvestmentSelection: new InvestmentSelection
                    (
                        3000, 0, 800, 3200
                    ),
                    BondInterestRate: 0.03,
                    BondDefaultRate: 0.07
                );

            var result = UnderTest.Calculate(requiredData);
            var expirationYears = result
                .Select(bond => bond.YearsToExpiration)
                .ToArray();

            Assert.AreEqual(new[] { 11 }, expirationYears);
        }

        [Test]
        public void NewBondPaymentsAreCreated()
        {
            var newBondPaymentValue = 2000;

            var requiredData = new NewBondRequiredData
                (
                    CurrentBonds: new BondHoldings
                    (
                        new[] { new BondHolding(2500, 12), new BondHolding(3000, 7) }
                    ),
                    InvestmentSelection: new InvestmentSelection
                    (
                        3000, newBondPaymentValue, 800, 3200
                    ),
                    BondInterestRate: 0.03,
                    BondDefaultRate: 0.07
                );

            var result = UnderTest.Calculate(requiredData);
            var expirationYears = result.Skip(2).First();

            Assert.AreEqual(new BondHolding(newBondPaymentValue, BondDefaultMaturity), expirationYears);
        }
    }
}
