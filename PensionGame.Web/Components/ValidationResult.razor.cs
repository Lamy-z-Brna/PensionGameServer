using Microsoft.AspNetCore.Components;
using PensionGame.Api.Domain.Validation;

namespace PensionGame.Web.Components
{
    public partial class ValidationResult
    {
        [Parameter]
        public ValidationResultModel? ResultModel { get; set; }
    }
}
