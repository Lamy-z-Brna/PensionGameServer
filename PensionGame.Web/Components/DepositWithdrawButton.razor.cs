using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using static PensionGame.Web.Components.BinaryButton;

namespace PensionGame.Web.Components
{
    public partial class DepositWithdrawButton
    {
        public enum TransactionDirection
        {
            Deposit,
            Withdraw
        }

        [Parameter]
        public EventCallback<TransactionDirection> OnPositionChanged { get; set; }

        private async Task HandlePositionChanged((Position, Position) positionChange)
        {
            var (_, newPosition) = positionChange;

            switch (newPosition)
            {
                case Position.Positive:
                    await OnPositionChanged.InvokeAsync(TransactionDirection.Deposit);
                    break;
                case Position.Negative:
                    await OnPositionChanged.InvokeAsync(TransactionDirection.Withdraw);
                    break;
            }
        }
    }
}
