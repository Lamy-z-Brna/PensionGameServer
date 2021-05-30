using Microsoft.AspNetCore.Components;

namespace PensionGame.Web.Components
{
    public partial class Tooltip
    {
        [Parameter] 
        public RenderFragment? ChildContent { get; set; }

        [Parameter] 
        public string? Text { get; set; }
    }
}
