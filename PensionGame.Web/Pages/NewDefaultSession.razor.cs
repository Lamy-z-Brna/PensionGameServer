
namespace PensionGame.Web.Pages
{
    public partial class NewDefaultSession
    {
        protected override async void OnInitialized()
        {
            var sessionId = await SessionService.CreateDefaultSession();
            navigationManager.NavigateTo($"/game/{sessionId.Id}");
        }
    }
}