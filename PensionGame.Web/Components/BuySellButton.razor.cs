using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using static PensionGame.Web.Components.BinaryButton;

namespace PensionGame.Web.Components
{
    public partial class BuySellButton
    {
        public enum OrderDirection
        {
            Buy,
            Sell
        }

        [Parameter]
        public EventCallback<OrderDirection> OnPositionChanged { get; set; }

        private async Task HandlePositionChanged((Position, Position) positionChange)
        {
            var (_, newPosition) = positionChange;

            switch (newPosition)
            {
                case Position.Positive:
                    await OnPositionChanged.InvokeAsync(OrderDirection.Buy);
                    break;
                case Position.Negative:
                    await OnPositionChanged.InvokeAsync(OrderDirection.Sell);
                    break;
            }
        }
    }
}
