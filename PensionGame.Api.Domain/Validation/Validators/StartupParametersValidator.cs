using FluentValidation;
using PensionGame.Api.Domain.Resources.Session;

namespace PensionGame.Api.Domain.Validation.Validators
{
    public sealed class StartupParametersValidator : AbstractValidator<StartupParameters>
    {
        public StartupParametersValidator()
        {
            RuleFor(x => x.Income)
                .GreaterThan(x => x.Expenses)
                .GreaterThan(0)
                .LessThanOrEqualTo(100000000);
            RuleFor(x => x.Expenses)
                .GreaterThan(0)
                .LessThanOrEqualTo(100000000);
            RuleFor(x => x.Year)
                 .GreaterThanOrEqualTo(18)
                 .LessThanOrEqualTo(100)
                 .LessThan(x => x.RetirementYear);
            RuleFor(x => x.RetirementYear)
                .GreaterThanOrEqualTo(18)
                .LessThanOrEqualTo(100);
        }
    }
}
