namespace PensionGame.Core.Calculators.Common
{
    public interface ICalculator<in TRequiredData, out TResult>
    {
        TResult Calculate(TRequiredData requiredData);
    }
}
