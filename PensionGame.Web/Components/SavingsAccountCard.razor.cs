using Microsoft.AspNetCore.Components;
using PensionGame.Api.Domain.Resources.Holdings;
using PensionGame.Web.Helpers;
using System;
using System.Threading.Tasks;
using static PensionGame.Web.Components.DepositWithdrawButton;

namespace PensionGame.Web.Components
{
    public partial class SavingsAccountCard
    {
        private const string SavingsAccountInfo = "An investment with very small but guaranteed returns. You can add and withdraw your investment at any moment, making it highly liquid. Any remaining disposable income will be automatically invested here.";

        [Parameter]
        public SavingsAccountHoldings? SavingsAccountData { get; set; }

        [Parameter]
        public double SavingsAccountRate { get; set; }

        [Parameter]
        public EventCallback<int?> OnSavingsAccountSelectionChanged { get; set; }

        private int SavingsAccountValue => SavingsAccountData?.Amount ?? 0;

        private int? TransactionValue { get; set; }

        private TransactionDirection TransactionDirection { get; set; }

        private int? AfterTransactionValue => TransactionValue.HasValue  ? SavingsAccountValue + (TransactionDirection == TransactionDirection.Deposit ? TransactionValue : -TransactionValue) : null;

        private async Task HandleDepositWithdrawButton(TransactionDirection transactionDirection)
        {
            TransactionDirection = transactionDirection;
            await HandleTransactionChange(TransactionValue);
        }

        private async Task HandleTransactionValueChange(ChangeEventArgs changeEventArgs)
        {
            var transactionValue = changeEventArgs.GetInt();
            await HandleTransactionChange(transactionValue);
        }

        private async Task HandleTransactionChange(int? transactionValue)
        {
            TransactionValue = transactionValue.HasValue ?
                (TransactionDirection == TransactionDirection.Withdraw ?
                    Math.Min(transactionValue.Value, SavingsAccountValue)
                    : transactionValue)
                : null;

            await OnSavingsAccountSelectionChanged.InvokeAsync(AfterTransactionValue);
        }
    }
}
