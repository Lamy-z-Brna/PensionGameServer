using PensionGame.Core.Calculators.Parameters;
using PensionGame.Core.Calculators.RequiredData;
using PensionGame.Core.Common;
using PensionGame.Core.Domain.Holdings;
using System.Collections.Generic;
using System.Linq;

namespace PensionGame.Core.Calculators
{
    public sealed class NewBondCalculator : INewBondCalculator
    {
        private readonly INewBondParameters _newBondParameters;
        private readonly IBondPaymentCalculator _bondPaymentCalculator;

        public NewBondCalculator(INewBondParameters newBondParameters, 
            IBondPaymentCalculator bondPaymentCalculator)
        {
            _newBondParameters = newBondParameters;
            _bondPaymentCalculator = bondPaymentCalculator;
        }

        public BondHoldings Calculate(NewBondRequiredData requiredData)
        {
            var investmentSelection = requiredData.InvestmentSelection;
            var bondRate = requiredData.BondInterestRate;

            var maturedBonds = MatureBonds(requiredData.CurrentBonds);

            var bondPaymentValue = _bondPaymentCalculator.Calculate
                (
                    new BondPaymentRequiredData
                    (
                        Maturity: _newBondParameters.DefaultMaturity,
                        Price: investmentSelection.BondValue,
                        BondInterestRate: bondRate
                    )
                );

            var bonds = AddNewBonds(maturedBonds, bondPaymentValue, _newBondParameters.DefaultMaturity);

            return new BondHoldings(bonds);
        }

        private static IEnumerable<BondHolding> MatureBonds(IEnumerable<BondHolding> bondHoldings)
        {
            return bondHoldings
                .Select(bond => bond with { YearsToExpiration = bond.YearsToExpiration - 1 })
                .Where(bond => bond.YearsToExpiration > 0);
        }

        private static IEnumerable<BondHolding> AddNewBonds(IEnumerable<BondHolding> bondHoldings, double yearlyPayment, int maturity)
        {
            return bondHoldings
                .Append(new BondHolding(Rounder.Round(yearlyPayment), maturity))
                .Where(bond => bond.YearlyPayment > 0);
        }
    }
}
