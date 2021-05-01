using System;

namespace PensionGame.Api.Domain.Validation
{
    [Serializable]
    public class ValidationException : Exception
    {
        public ValidationResultModel ValidationModel { get; }

        public ValidationException(string message) : base(message)
        {
            ValidationModel = new ValidationResultModel(new[] { new ValidationErrorModel(message) });
        }
    }
}
