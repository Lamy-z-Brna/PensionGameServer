using PensionGame.Core.Calculators.Common;

namespace PensionGame.Core.Calculators.Parameters
{
    public interface IPreClientDataEventParameters : ICalculatorParameters
    {
        double UnemploymentIncomeLoss { get; }
    }
}
