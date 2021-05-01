using System.Collections.Generic;

namespace PensionGame.Api.Domain.Validation
{
    public sealed record ValidationResultModel(IReadOnlyCollection<ValidationErrorModel> Errors)
    {
    }
}
