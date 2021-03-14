﻿using FluentValidation;
using FluentValidation.Results;
using PensionGame.Api.Resources.ClientData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PensionGame.Host.Validators
{
    public sealed class InvestmentSelectionValidator : AbstractValidator<InvestmentSelection>
    {
        public InvestmentSelectionValidator()
        {
            RuleFor(x => x.StockValue)
                    .GreaterThanOrEqualTo(0)
                    .LessThanOrEqualTo(100000000);
            RuleFor(x => x.BondValue)
                .GreaterThanOrEqualTo(0)
                .LessThanOrEqualTo(100000000);
            RuleFor(x => x.SavingsAccountValue)
                .GreaterThanOrEqualTo(0)
                .LessThanOrEqualTo(100000000);
            RuleFor(x => x.LoanValue)
                .GreaterThanOrEqualTo(0)
                .LessThanOrEqualTo(100000000);
        }
    }
}
