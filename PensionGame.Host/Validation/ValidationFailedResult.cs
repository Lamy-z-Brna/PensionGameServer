using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using PensionGame.Api.Domain.Validation;
using System.Linq;

namespace PensionGame.Host.Validation
{
    public class ValidationFailedResult : ObjectResult
    {
        public ValidationFailedResult(ModelStateDictionary modelState)
            : base(new ValidationResultModel(modelState.Keys
                    .SelectMany(key => modelState[key].Errors.Select(x => new ValidationErrorModel(key, x.ErrorMessage)))
                    .ToList()))
        {
            StatusCode = StatusCodes.Status422UnprocessableEntity;
        }

        public ValidationFailedResult(ValidationResultModel validationResultModel)
            : base(validationResultModel)
        {
            StatusCode = StatusCodes.Status422UnprocessableEntity;
        }
    }
}
