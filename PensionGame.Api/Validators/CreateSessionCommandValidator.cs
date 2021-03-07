using FluentValidation;
using PensionGame.Api.Domain.Session;
using PensionGame.Api.Handlers.Commands;

namespace PensionGame.Api.Validators
{
    public sealed class CreateSessionCommandValidator : AbstractValidator<CreateSessionCommand>
    {
        public CreateSessionCommandValidator()
        {
            RuleFor(x => x.StartupParameters)
#pragma warning disable CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
                .SetValidator(new StartupParametersValidator())
#pragma warning restore CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
                .When(x => x.StartupParameters != null);
        }

        class StartupParametersValidator : AbstractValidator<StartupParameters>
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
}
