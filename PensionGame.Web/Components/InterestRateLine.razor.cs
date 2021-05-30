using Microsoft.AspNetCore.Components;

namespace PensionGame.Web.Components
{
    public partial class InterestRateLine
    {
        [Parameter]
        public double InterestRate { get; set; }
    }
}
