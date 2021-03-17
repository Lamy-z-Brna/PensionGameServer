using Microsoft.AspNetCore.Mvc.Filters;
using PensionGame.Api.Domain.Validation;
using PensionGame.Host.Validation;

namespace PensionGame.Host.Exception_Handling
{
    public class ExceptionHandlingAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is ValidationException validationException)
            {
                context.Result = new ValidationFailedResult(validationException.ValidationModel);
                return;
            }

            base.OnException(context);
        }
    }
}
