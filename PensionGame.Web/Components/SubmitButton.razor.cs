using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace PensionGame.Web.Components
{
    public partial class SubmitButton : ComponentBase
    {
        [Parameter]
        public bool IsDisabled { get; set; }

        [Parameter]
        public EventCallback OnSubmit { get; set; }

        private bool IsSubmitted { get; set; }

        private async Task InvokeOnSubmit()
        {
            IsSubmitted = true;

            try
            {
                await OnSubmit.InvokeAsync();
            }
            finally
            {
                IsSubmitted = false;
            }
        }
    }
}
