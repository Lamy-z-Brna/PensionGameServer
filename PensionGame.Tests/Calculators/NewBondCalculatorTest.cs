using Moq;
using NUnit.Framework;
using PensionGame.Core.Calculators;
using PensionGame.Core.Calculators.Parameters;
using PensionGame.Core.Calculators.RequiredData;
using PensionGame.Core.Domain.ClientData;
using PensionGame.Core.Domain.Holdings;
using PensionGame.Core.Events;
using System.Linq;
using System;
using PensionGame.Core.Events.Common;
using PensionGame.Core.Calculators.Holdings;

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

            var mockedBondDefaultCalculator = new Mock<IBondDefaultCalculator>();

            mockedBondDefaultCalculator
                .Setup(x => x.Calculate(It.IsAny<BondDefaultRequiredData>()))
                .Returns<BondDefaultRequiredData>(required =>
                    required.BondDefaultRate > 0.5 ? new BondDefaultEvent(required.BondHolding) : required.BondHolding);


            UnderTest = new NewBondCalculator(mockedBondParameters.Object, mockedBondPaymentCalculator.Object, mockedBondDefaultCalculator.Object);
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

            var (result, _) = UnderTest.Calculate(requiredData);
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

            var (result, _) = UnderTest.Calculate(requiredData);
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

            var (result, _) = UnderTest.Calculate(requiredData);
            var expirationYears = result.Skip(2).First();

            Assert.AreEqual(new BondHolding(newBondPaymentValue, BondDefaultMaturity), expirationYears);
        }

        [Test]
        public void WhenBondDefaults_EventIsGenerated()
        {
            var requiredData = new NewBondRequiredData
                (
                    CurrentBonds: new BondHoldings
                    (
                        new[] { new BondHolding(2500, 12) }
                    ),
                    InvestmentSelection: new InvestmentSelection
                    (
                        3000, 0, 800, 3200
                    ),
                    BondInterestRate: 0.03,
                    BondDefaultRate: 0.9
                );

            var (_, events) = UnderTest.Calculate(requiredData);

            Assert.AreEqual(new[] { new BondDefaultEvent(new BondHolding(2500, 11)) }, events);
        }

        [Test]
        public void WhenBondDefaultsAndExpires_NoEventGenerated()
        {
            var requiredData = new NewBondRequiredData
                (
                    CurrentBonds: new BondHoldings
                    (
                        new[] { new BondHolding(2500, 1) }
                    ),
                    InvestmentSelection: new InvestmentSelection
                    (
                        3000, 0, 800, 3200
                    ),
                    BondInterestRate: 0.03,
                    BondDefaultRate: 0.9
                );

            var (_, events) = UnderTest.Calculate(requiredData);

            Assert.AreEqual(Array.Empty<IEvent>(), events);
        }
    }
}