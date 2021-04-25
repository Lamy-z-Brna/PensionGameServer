using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace PensionGame.Web.Shared
{
    public partial class NavigationBar
    {
        [Parameter] 
        public EventCallback OnClick { get; set; }

        async Task InvokeOnClick()
        {
            await OnClick.InvokeAsync();
        }
    }
}
