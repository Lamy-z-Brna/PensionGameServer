using PensionGame.Api.Domain.Common;
using PensionGame.Api.Domain.Resources.Session;
using System.Threading.Tasks;

namespace PensionGame.Web.Pages
{
    public partial class AllSessions
    {
        PaginatedCollection<SessionInfo>? Sessions;

        protected override async void OnInitialized()
        {
            Sessions = await SessionService.GetAllSessions(1, 10);

            StateHasChanged();
        }

        private async Task UpdatePage(int page)
        {
            Sessions = await SessionService.GetAllSessions(page, 10);

            StateHasChanged();
        }
    }
}
