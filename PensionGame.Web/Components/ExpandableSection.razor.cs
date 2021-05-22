using Microsoft.AspNetCore.Components;

namespace PensionGame.Web.Components
{
    public partial class ExpandableSection
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }
        //[Parameter]
        public bool Collapsed { get; set; } = true;

        void Toggle()
        {
            Collapsed = !Collapsed;
        }
    }
}
