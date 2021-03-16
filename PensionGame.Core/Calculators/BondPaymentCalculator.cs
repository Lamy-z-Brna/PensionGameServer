using PensionGame.Core.Calculators.RequiredData;
using System;

namespace PensionGame.Core.Calculators
{
    public sealed class BondPaymentCalculator : IBondPaymentCalculator
    {
        public double Calculate(BondPaymentRequiredData requiredData)
        {
            var maturity = requiredData.Maturity;
            var interestRate = requiredData.BondInterestRate;
            var bondPrice = requiredData.Price;

            var interestMultiplier = 1 + interestRate;
            var interestCompound = Math.Pow(interestMultiplier, maturity);           

            return bondPrice * (interestCompound * interestMultiplier - interestCompound) / (interestCompound - 1);
        }
    }
}
