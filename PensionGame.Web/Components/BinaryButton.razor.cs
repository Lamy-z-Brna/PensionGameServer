using Microsoft.AspNetCore.Components;

namespace PensionGame.Web.Components
{
    public partial class BinaryButton
    {
        public enum Position
        {
            Positive,
            Negative
        }

        private Position _state = Position.Positive;
        public Position State 
        { 
            get => _state;
            private set
            {
                if (value != _state)
                {
                    var oldValue = _state;
                    _state = value;
                    OnPositionChanged.InvokeAsync((oldValue, _state));
                }
            }
        }

        [Parameter]
        public string PositiveCaption { get; set; } = "Buy";

        [Parameter]
        public string NegativeCaption { get; set; } = "Sell";

        [Parameter]
        public EventCallback<(Position, Position)> OnPositionChanged { get; set; }

        private void PositiveClicked()
        {
            State = Position.Positive;
        }

        private void NegativeClicked()
        {
            State = Position.Negative;
        }
    }
}