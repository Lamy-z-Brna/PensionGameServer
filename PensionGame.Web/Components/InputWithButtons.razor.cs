using Microsoft.AspNetCore.Components;
using PensionGame.Web.Helpers;
using System.Threading.Tasks;
using static PensionGame.Web.Components.BinaryButton;

namespace PensionGame.Web.Components
{
    public partial class InputWithButtons
    {
        private int? InputValue { get; set; }

        [Parameter]
        public string InputCaption { get; set; } = string.Empty;

        [Parameter]
        public string PositiveCaption { get; set; } = string.Empty;

        [Parameter]
        public string NegativeCaption { get; set; } = string.Empty;

        [Parameter]
        public int? Value
        {
            get => InputValue;
            set
            {
                if (InputValue == value) 
                    return;
                InputValue = value;
                ValueChanged.InvokeAsync(value);
            }
        }

        [Parameter]
        public EventCallback<int?> ValueChanged { get; set; }

        [Parameter]
        public EventCallback<Position> OnPositionChanged { get; set; }        

        [Parameter]
        public EventCallback<int?> OnInputChanged { get; set; }

        private async Task HandlePositionChanged((Position, Position) positionChange)
        {
            await OnPositionChanged.InvokeAsync(positionChange.Item2);
        }

        private async Task HandleInputChanged(ChangeEventArgs changeEventArgs)
        {
            var value = changeEventArgs.GetInt();
            await OnInputChanged.InvokeAsync(value);
        }
    }
}
