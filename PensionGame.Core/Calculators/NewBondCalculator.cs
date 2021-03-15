using PensionGame.Core.Calculators.Common;
using PensionGame.Core.Calculators.RequiredData;
using PensionGame.Core.Common;
using PensionGame.Core.Domain.Holdings;
using System.Linq;

namespace PensionGame.Core.Calculators
{
    public sealed class NewBondCalculator : INewBondCalculator
    {
        private readonly INewBondParameters _newBondParameters;

        public NewBondCalculator(INewBondParameters newBondParameters)
        {
            _newBondParameters = newBondParameters;
        }

        public BondHoldings Calculate(NewBondRequiredData requiredData)
        {
            var investmentSelection = requiredData.InvestmentSelection;
            var bondRate = requiredData.BondInterestRate;

            var bonds = requiredData.CurrentBonds
                .Select(bond => bond with { YearsToExpiration = bond.YearsToExpiration - 1 })
                .Where(bond => bond.YearsToExpiration > 0)
                .ToList();

            bonds.Add(new BondHolding(Rounder.Round(investmentSelection.BondValue * (1 + bondRate)), _newBondParameters.DefaultMaturity));

            return new BondHoldings(bonds);
        }
    }
}
