using System;
using System.Collections.Generic;

namespace PensionGame.Api.Domain.Validation
{
    [Serializable]
    public sealed class ValidationException : Exception
    {
        public ValidationResultModel ValidationModel { get; }

        public ValidationException(string message) : base(message)
        {
            ValidationModel = new ValidationResultModel(message);
        }

        public ValidationException(ValidationResultModel validationResultModel) : base("Validation Failed")
        {
            ValidationModel = validationResultModel;
        }
    }
}
