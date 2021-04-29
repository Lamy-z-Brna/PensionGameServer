using PensionGame.Common.Functional;
using PensionGame.Core.Calculators.Parameters;
using PensionGame.Core.Calculators.RequiredData;
using PensionGame.Core.Common;
using PensionGame.Core.Domain.Holdings;
using PensionGame.Core.Events;
using PensionGame.Core.Events.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PensionGame.Core.Calculators.Holdings
{
    public sealed class NewBondCalculator : INewBondCalculator
    {
        private readonly INewBondParameters _newBondParameters;
        private readonly IBondPaymentCalculator _bondPaymentCalculator;
        private readonly IBondDefaultCalculator _bondDefaultCalculator;

        public NewBondCalculator(INewBondParameters newBondParameters,
            IBondPaymentCalculator bondPaymentCalculator,
            IBondDefaultCalculator bondDefaultCalculator)
        {
            _newBondParameters = newBondParameters;
            _bondPaymentCalculator = bondPaymentCalculator;
            _bondDefaultCalculator = bondDefaultCalculator;
        }

        public (BondHoldings, IReadOnlyCollection<IEvent>) Calculate(NewBondRequiredData requiredData)
        {
            var (currentBonds, investmentSelection, bondRate, bondDefaultRate) = requiredData;

            var bondPaymentValue = _bondPaymentCalculator.Calculate
                (
                    new BondPaymentRequiredData
                    (
                        Maturity: _newBondParameters.DefaultMaturity,
                        Price: investmentSelection.BondValue,
                        BondInterestRate: bondRate
                    )
                );

            BondHoldings addNewBonds(BondHoldings holdings) => AddNewBonds(holdings, bondPaymentValue, _newBondParameters.DefaultMaturity);
            (BondHoldings, IReadOnlyCollection<IEvent>) defaultBonds(BondHoldings bondHoldings) =>
                DefaultBonds(bondHoldings, bond => _bondDefaultCalculator.Calculate(new BondDefaultRequiredData(bond, bondDefaultRate)));

            return currentBonds.Pipe
                (
                    MatureBonds,
                    addNewBonds,
                    defaultBonds
                );
        }

        private static BondHoldings MatureBonds(BondHoldings bondHoldings)
        {
            return bondHoldings
                .Select(bond => bond with { YearsToExpiration = bond.YearsToExpiration - 1 })
                .Where(bond => bond.YearsToExpiration > 0)
                .ToBonds();
        }

        private static BondHoldings AddNewBonds(BondHoldings bondHoldings, double yearlyPayment, int maturity)
        {
            return bondHoldings
                .Append(new BondHolding(Rounder.Round(yearlyPayment), maturity))
                .Where(bond => bond.YearlyPayment > 0)
                .ToBonds();
        }

        private static (BondHoldings, IReadOnlyCollection<IEvent>) DefaultBonds(BondHoldings bondHoldings, Func<BondHolding, Union<BondHolding, BondDefaultEvent>> defaultCalculator)
        {
            var eithers = bondHoldings.Select(defaultCalculator)
                .ToList();

            var (bonds, events) = eithers.ToTuple();

            return new(new BondHoldings(bonds), events);
        }
    }
}
