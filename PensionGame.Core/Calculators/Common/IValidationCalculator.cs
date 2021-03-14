using PensionGame.Core.Validation.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionGame.Core.Calculators.Common
{
    public interface IValidationCalculator<in TRequiredData, TResult> : ICalculator<TRequiredData, ValidationResult<TResult>>
    {
    }
}
