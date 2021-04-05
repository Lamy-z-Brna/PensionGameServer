namespace PensionGame.Core.Calculators.Common
{
    public interface IGenerator<out TResult>
    {
        TResult Generate();
    }
}
