using Microsoft.AspNetCore.Components;
using PensionGame.Api.Domain.Common;
using PensionGame.Api.Domain.Resources.Session;
using PensionGame.Web.Helpers;
using PensionGame.Web.Infrastructure;
using PensionGame.Web.Services;
using System.Threading.Tasks;

namespace PensionGame.Web.Pages
{
    public partial class AllSessions : ReloadableComponent
    {
        [Inject]
        public BrowserService? BrowserService { get; set; }

        private const int DefaultPage = 1;
        private const int DefaultPageSize = 10;

        private PaginatedCollection<SessionInfo>? Sessions { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }

        private bool IsSmallScreen { get; set; }

        protected override async void OnInitialized()
        {
            Page = DefaultPage;
            PageSize = DefaultPageSize;

            await Reload(UpdateSessions);
        }

        private async Task UpdatePage(int page)
        {
            Page = page;
            await Reload(UpdateSessions);
        }

        private async Task UpdatePageSize(int pageSize)
        {
            Page = DefaultPage;
            PageSize = pageSize;
            await Reload(UpdateSessions);
        }

        private async Task UpdateSessions()
        {           
            Sessions = await SessionService.GetAllSessions(Page, PageSize);
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            var dimensions = await BrowserService!.GetDimensions();

            IsSmallScreen = dimensions.Width < SizeHelper.SmallWindowWidth;
        }
    }

}
