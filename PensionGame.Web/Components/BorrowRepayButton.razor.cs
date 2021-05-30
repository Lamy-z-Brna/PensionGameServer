using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using static PensionGame.Web.Components.BinaryButton;

namespace PensionGame.Web.Components
{
    public partial class BorrowRepayButton
    {
        public enum LoanAction
        {
            Borrow,
            Repay
        }

        [Parameter]
        public EventCallback<LoanAction> OnPositionChanged { get; set; }

        private async Task HandlePositionChanged((Position, Position) positionChange)
        {
            var (_, newPosition) = positionChange;

            switch (newPosition)
            {
                case Position.Positive:
                    await OnPositionChanged.InvokeAsync(LoanAction.Borrow);
                    break;
                case Position.Negative:
                    await OnPositionChanged.InvokeAsync(LoanAction.Repay);
                    break;
            }
        }
    }
}
