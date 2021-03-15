namespace PensionGame.Core.Calculators.Common
{
    public interface INewBondParameters : ICalculatorParameters
    {
        int DefaultMaturity { get; }
    }
}
