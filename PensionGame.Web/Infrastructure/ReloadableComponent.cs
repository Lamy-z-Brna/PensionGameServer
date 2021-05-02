using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace PensionGame.Web.Infrastructure
{
    public abstract class ReloadableComponent : ComponentBase
    {
        protected bool IsLoading { get; private set; }

        protected async Task Reload(Func<Task> action)
        {
            IsLoading = true;
            await action();
            IsLoading = false;
            StateHasChanged();
        }
    }
}
