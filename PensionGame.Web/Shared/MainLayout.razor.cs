using Microsoft.AspNetCore.Components;
using PensionGame.Web.Services;
using System.Threading.Tasks;

namespace PensionGame.Web.Shared
{
    public partial class MainLayout
    {
        [Inject]
        public BrowserService? BrowserService { get; set; }
        
        private bool Collapsed { get; set; }

        void ToggleNavMenu()
        {
            Collapsed = !Collapsed;

            StateHasChanged();
        }

        async Task CollapseForSmallScreens()
        {
            var dimensions = await BrowserService!.GetDimensions();

            if (dimensions.Width < 992)
                Collapsed = !Collapsed;

            StateHasChanged();
        }
    }
}
