using Microsoft.AspNetCore.Components;

namespace PensionGame.Web.Shared
{
    public partial class NavigationMenu
    {
        [Parameter]
        public bool Collapsed { get; set; }
    }
}
