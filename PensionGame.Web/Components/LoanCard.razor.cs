using Microsoft.AspNetCore.Components;
using PensionGame.Api.Domain.Resources.Holdings;
using PensionGame.Web.Helpers;
using System;
using System.Threading.Tasks;
using static PensionGame.Web.Components.BorrowRepayButton;

namespace PensionGame.Web.Components
{
    public partial class LoanCard
    {
        private const string LoanInfo = "A very expensive way to get extra money for investments. Interest will be charged every year until you pay your loans back.";

        [Parameter]
        public LoanHoldings? LoanData { get; set; }

        [Parameter]
        public double LoanRate { get; set; }

        [Parameter]
        public EventCallback<int?> OnLoanValueChange { get; set; }

        private int LoanValue => LoanData?.TotalLoanValue ?? 0;

        private int? LoanActionValue { get; set; }

        private LoanAction LoanAction { get; set; }

        private int? AfterActionValue => LoanActionValue.HasValue ? LoanValue + (LoanAction == LoanAction.Borrow ? LoanActionValue : -LoanActionValue) : null;

        private async Task HandleBorrowRepayButton(LoanAction loanAction)
        {
            LoanAction = loanAction;
            await HandleLoanChange(LoanValue);
        }

        public async Task HandleLoanActionValueChange(ChangeEventArgs changeEventArgs)
        {
            var loanValue = changeEventArgs.GetInt();
            await HandleLoanChange(loanValue);
        }

        public async Task HandleLoanChange(int? loanActionValue)
        {
            LoanActionValue = loanActionValue.HasValue ?
                (LoanAction == LoanAction.Repay ?
                    Math.Min(loanActionValue.Value, LoanValue)
                    : loanActionValue)
                : null;

            await OnLoanValueChange.InvokeAsync(AfterActionValue);
        }
    }
}
