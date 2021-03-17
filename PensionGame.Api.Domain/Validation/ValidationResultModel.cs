using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace PensionGame.Api.Domain.Validation
{
    public sealed class ValidationResultModel
    {
        public static string Message => "Validation Failed";

        public IEnumerable<ValidationErrorModel> Errors { get; }

        public ValidationResultModel(ModelStateDictionary modelState)
        {
            Errors = modelState.Keys
                    .SelectMany(key => modelState[key].Errors.Select(x => new ValidationErrorModel(key, x.ErrorMessage)))
                    .ToList();
        }

        public ValidationResultModel(string errorMessage)
        {
            Errors = new[] { new ValidationErrorModel(errorMessage) };
        }

        public ValidationResultModel(IEnumerable<string> errorMessages)
        {
            Errors = errorMessages.Select(errorMessage => new ValidationErrorModel(errorMessage));
        }
    }
}
