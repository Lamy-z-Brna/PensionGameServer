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
        public string PositiveCaption { get; set; } = string.Empty;

        [Parameter]
        public string NegativeCaption { get; set; } = string.Empty;

        [Parameter]
        public EventCallback<(Position, Position)> OnPositionChanged { get; set; }

        [Parameter]
        public bool IsPositiveOnly { get; set; }

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