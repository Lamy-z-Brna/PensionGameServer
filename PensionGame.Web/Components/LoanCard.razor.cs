using Microsoft.AspNetCore.Components;
using PensionGame.Api.Domain.Resources.Holdings;
using System;
using System.Threading.Tasks;
using static PensionGame.Web.Components.BinaryButton;

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

        private LoanAction Direction { get; set; }

        private int? AfterActionValue => LoanActionValue.HasValue ? LoanValue + (Direction == LoanAction.Borrow ? LoanActionValue : -LoanActionValue) : null;

        private async Task HandleBorrowRepayButton(Position position)
        {
            Direction = position == Position.Positive ? LoanAction.Borrow : LoanAction.Repay;
            await HandleLoanChange(LoanActionValue);
        }

        public async Task HandleLoanActionValueChange(int? loanValue)
        {
            await HandleLoanChange(loanValue);
        }

        public async Task HandleLoanChange(int? loanActionValue)
        {
            LoanActionValue = loanActionValue.HasValue ?
                (Direction == LoanAction.Repay ?
                    Math.Min(loanActionValue.Value, LoanValue)
                    : loanActionValue)
                : null;

            await OnLoanValueChange.InvokeAsync(AfterActionValue);
        }

        private enum LoanAction
        {
            Borrow,
            Repay
        }
    }
}
