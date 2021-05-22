using Microsoft.AspNetCore.Components;

namespace PensionGame.Web.Components
{
    public partial class Card
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }
    }
}
