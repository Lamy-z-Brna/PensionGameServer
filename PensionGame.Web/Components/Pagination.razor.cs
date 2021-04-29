using Microsoft.AspNetCore.Components;
using PensionGame.Api.Domain.Common;
using System.Threading.Tasks;

namespace PensionGame.Web.Components
{
    public partial class Pagination<TItem> : ComponentBase
    {
        [Parameter]
        public PaginatedCollection<TItem>? Items { get; set; }

        [Parameter]
        public EventCallback<int> OnPageClicked { get; set; }

        [Parameter]
        public EventCallback<int> OnPageSizeChanged { get; set; }

        private async Task InvokeOnPageClicked(int page)
        {
            await OnPageClicked.InvokeAsync(page);
        }

        private async Task InvokeOnPageSizeChanged(int pageSize)
        {
            await OnPageSizeChanged.InvokeAsync(pageSize);
        }
    }
}
