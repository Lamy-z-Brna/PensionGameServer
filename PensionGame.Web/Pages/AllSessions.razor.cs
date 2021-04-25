using PensionGame.Api.Domain.Common;
using PensionGame.Api.Domain.Resources.Session;
using System.Threading.Tasks;

namespace PensionGame.Web.Pages
{
    public partial class AllSessions
    {
        private const int DefaultPage = 1;
        private const int DefaultPageSize = 10;

        private PaginatedCollection<SessionInfo>? Sessions { get; set; }        

        public int Page { get; set; }

        public int PageSize { get; set; }

        protected override async void OnInitialized()
        {
            Page = DefaultPage;
            PageSize = DefaultPageSize;

            await UpdateSessions();
            StateHasChanged();
        }

        private async Task UpdatePage(int page)
        {
            Page = page;

            await UpdateSessions();
            StateHasChanged();
        }

        private async Task UpdatePageSize(int pageSize)
        {
            Page = DefaultPage;
            PageSize = pageSize;

            await UpdateSessions();
            StateHasChanged();
        }

        private async Task UpdateSessions()
        {
            Sessions = await SessionService.GetAllSessions(Page, PageSize);
        }
    }
}
