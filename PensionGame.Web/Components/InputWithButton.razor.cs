using Microsoft.AspNetCore.Components;
using PensionGame.Web.Helpers;
using System.Threading.Tasks;

namespace PensionGame.Web.Components
{
    public partial class InputWithButton
    {
        private int? InputValue { get; set; }

        [Parameter]
        public string ButtonCaption { get; set; } = string.Empty;

        [Parameter]
        public string InputCaption { get; set; } = string.Empty;

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
        public EventCallback<int?> OnInputChanged { get; set; }

        private async Task HandleInputChanged(ChangeEventArgs changeEventArgs)
        {
            var value = changeEventArgs.GetInt();
            await OnInputChanged.InvokeAsync(value);
        }
    }
}
