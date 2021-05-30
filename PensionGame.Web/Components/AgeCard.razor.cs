using Microsoft.AspNetCore.Components;

namespace PensionGame.Web.Components
{
    public partial class AgeCard
    {
        [Parameter]
        public int Age { get; set; }
    }
}
