using Microsoft.AspNetCore.Components;
using PensionGame.Api.Domain.Resources.Holdings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PensionGame.Web.Components
{
    public partial class BondCard
    {
        private const string BondInfo = "Bonds are a long term investment with above average returns, but low liquidity. Bonds yield coupons of the same amount every year until they expire (10 years). You cannot disinvest bonds and have to wait until they expire.";

        [Parameter]
        public BondHoldings? BondData { get; set; }

        [Parameter]
        public double BondRate { get; set; }

        [Parameter]
        public EventCallback<int> OnBondSelectionChanged { get; set; }

        private int BondValue => BondData?.Value ?? 0;

        private int? OrderValue { get; set; }

        private int AfterOrderValue => BondValue + (OrderValue ?? 0);

        private async Task HandleOrderValueChange(ChangeEventArgs changeEventArgs)
        {
            OrderValue = ParseInt(changeEventArgs);
            await OnBondSelectionChanged.InvokeAsync(OrderValue ?? 0);
        }

        private static int ParseInt(ChangeEventArgs changeEventArgs)
        {
            if (changeEventArgs.Value is not string text)
                return 0;

            _ = int.TryParse(text, out var result);

            return result;
        }
    }
}
