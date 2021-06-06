using Microsoft.AspNetCore.Components;

namespace PensionGame.Web.Components
{
    public partial class HoldingCard
    {
        [Parameter]
        public string Title { get; set; } = string.Empty;

        [Parameter]
        public string InfoTooltip { get; set; } = string.Empty;        

        [Parameter]
        public int Value { get; set; }

        [Parameter]
        public string ValueTooltip { get; set; } = string.Empty;

        [Parameter]
        public RenderFragment? ChildContent { get; set; }
    }
}
