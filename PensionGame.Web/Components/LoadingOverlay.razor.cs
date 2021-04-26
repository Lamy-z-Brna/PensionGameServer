using Microsoft.AspNetCore.Components;

namespace PensionGame.Web.Components
{
    public partial class LoadingOverlay
    {
        [Parameter]
        public bool IsLoading { get; set; }
    }
}
