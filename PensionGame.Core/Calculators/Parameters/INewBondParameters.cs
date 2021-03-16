using PensionGame.Core.Calculators.Common;

namespace PensionGame.Core.Calculators.Parameters
{
    public interface INewBondParameters : ICalculatorParameters
    {
        int DefaultMaturity { get; }
    }
}
