using System.Collections.Generic;
using System.Linq;

namespace PensionGame.Api.Domain.Validation
{
    public sealed record ValidationResultModel(IReadOnlyCollection<ValidationErrorModel> Errors)
    {
        public ValidationResultModel() : this(new List<ValidationErrorModel>())
        {
        }        

        public bool IsFailed => Errors.Any();
    }
}
