using Microsoft.AspNetCore.Components;

namespace PensionGame.Web.Components
{
    public partial class AvailableToInvestCard
    {
        private const string Info = "The amount you can spend with your current selection of investments and loans";

        [Parameter]
        public int AvailableToInvest { get; set; }
    }
}
