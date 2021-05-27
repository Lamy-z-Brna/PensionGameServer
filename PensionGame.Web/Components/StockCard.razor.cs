using Microsoft.AspNetCore.Components;
using PensionGame.Api.Domain.Resources.Holdings;
using System;
using System.Globalization;
using PensionGame.Common.Functional;
using static PensionGame.Web.Components.BuySellButton;
using System.Threading.Tasks;

namespace PensionGame.Web.Components
{
    public partial class StockCard
    {
        [Parameter]
        public StockHolding? StockData { get; set; }

        [Parameter]
        public EventCallback<int> OnStockSelectionChanged { get; set; }

        private double StockPrice => StockData?.UnitPrice.Price ?? 0;

        private int StockValue => StockData?.Value ?? 0;

        private double? OrderQuantity { get; set; }

        private int? OrderValue { get; set; }

        private OrderDirection OrderDirection { get; set; }

        private int AfterOrderValue => StockValue + ((OrderDirection == OrderDirection.Buy ? OrderValue : -OrderValue) ?? 0);

        private async Task HandleBuySellButton(OrderDirection newPosition)
        {
            OrderDirection = newPosition;
            await HandleOrderChange(OrderValue.HasValue ? new Value(OrderValue.Value) : new None());
        }

        private async Task HandleQuantityChange(ChangeEventArgs changeEventArgs)
        {
            var newQuantity = ParseDouble(changeEventArgs);
            await HandleOrderChange (new Quantity(newQuantity));
        }

        private async Task HandleValueChange(ChangeEventArgs changeEventArgs)
        {
            var newValue = ParseInt(changeEventArgs);
            await HandleOrderChange(new Value(newValue));
        }

        private async Task HandleOrderChange(Union<Value, Quantity, None> orderChange)
        {
            var newOrder = orderChange.Match(
                value => OrderDirection == OrderDirection.Sell && value.Amount > StockValue ? new Value(StockValue) : new Value(value.Amount),
                quantity => OrderDirection == OrderDirection.Sell && quantity.Amount * StockPrice > StockValue ? new Quantity(StockValue / StockPrice) : quantity,
                none => none
                );

            newOrder.Do(
                value =>
                {
                    OrderValue = value.Amount;
                    OrderQuantity = Math.Round(value.Amount / StockPrice, 2);
                },
                quantity =>
                {
                    OrderQuantity = Math.Round(quantity.Amount, 2);
                    OrderValue = (int)(quantity.Amount * StockPrice);
                },
                none =>
                {
                    OrderQuantity = null;
                    OrderValue = null;
                }
                );

            await OnStockSelectionChanged.InvokeAsync(AfterOrderValue);
        }

        private static double ParseDouble(ChangeEventArgs changeEventArgs)
        {
            if (changeEventArgs.Value is not string text)
                return 0;

            _ = double.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out var result);

            return result;
        }

        private static int ParseInt(ChangeEventArgs changeEventArgs)
        {
            if (changeEventArgs.Value is not string text)
                return 0;

            _ = int.TryParse(text, out var result);

            return result;
        }

        private record Quantity(double Amount);

        private record Value(int Amount);
    }
}
