using FluentValidation;
using PensionGame.Api.Resources.Session;

namespace PensionGame.Host.Validators
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
                 .GreaterThanOrEqualTo(20)
                 .LessThanOrEqualTo(100)
                 .LessThan(x => x.RetirementYear);
            RuleFor(x => x.RetirementYear)
                .GreaterThanOrEqualTo(20)
                .LessThanOrEqualTo(100);
        }
    }
}
