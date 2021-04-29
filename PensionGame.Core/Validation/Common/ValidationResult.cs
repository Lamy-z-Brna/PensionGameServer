using PensionGame.Common.Functional;
using System;

namespace PensionGame.Core.Validation.Common
{
    public sealed class ValidationResult<TObj> : Union<TObj, ValidationError>
    {
        public ValidationResult(TObj obj) : base(obj)
        {
        }

        public ValidationResult(ValidationError error) : base(error)
        {
        }

        public void OnError(Action<ValidationError> action)
        {
            Do((obj) => { }, action);
        }
    }
}
