using PensionGame.Api.Domain.Common;
using PensionGame.Api.Domain.Resources.Session;

namespace PensionGame.Web.Pages
{
    public partial class AllSessions
    {
        PaginationResult<Session>? Sessions;

        protected override async void OnInitialized()
        {
            Sessions = await SessionService.GetAllSessions();

            StateHasChanged();
        }
    }
}
