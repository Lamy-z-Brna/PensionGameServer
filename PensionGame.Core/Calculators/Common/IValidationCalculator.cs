using PensionGame.Core.Validation.Common;

namespace PensionGame.Core.Calculators.Common
{
    public interface IValidationCalculator<in TRequiredData, TResult> : ICalculator<TRequiredData, ValidationResult<TResult>>
    {
    }
}
