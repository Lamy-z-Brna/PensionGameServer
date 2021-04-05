using PensionGame.Core.Calculators.Parameters;
using PensionGame.Core.Calculators.RequiredData;
using PensionGame.Core.Common;
using PensionGame.Core.Domain.Holdings;
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
            var currentBonds = requiredData.CurrentBonds;

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

            return currentBonds.Pipe
                (
                    MatureBonds,
                    addNewBonds
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
    }
}
