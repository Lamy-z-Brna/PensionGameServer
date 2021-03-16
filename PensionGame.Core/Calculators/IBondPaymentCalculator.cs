using PensionGame.Core.Calculators.Common;
using PensionGame.Core.Calculators.RequiredData;

namespace PensionGame.Core.Calculators
{
    public interface IBondPaymentCalculator : ICalculator<BondPaymentRequiredData, double>
    {
    }
}
