using Microsoft.AspNetCore.Components;
using PensionGame.Api.Domain.Resources.Holdings;
using System;
using PensionGame.Common.Functional;
using static PensionGame.Web.Components.BuySellButton;
using System.Threading.Tasks;
using PensionGame.Web.Helpers;

namespace PensionGame.Web.Components
{
    public partial class StockCard
    {
        private const string StockInfo = "Stocks are a highly volatile liquid investment that has a high average returns. The price of stock market unit can vary widely from year to year, however you are able to buy and sell down units freely.";

        [Parameter]
        public StockHolding? StockData { get; set; }

        [Parameter]
        public EventCallback<int?> OnStockSelectionChanged { get; set; }

        private double StockPrice => StockData?.UnitPrice.Price ?? 0;

        private int StockValue => StockData?.Value ?? 0;

        private double? OrderQuantity { get; set; }

        private int? OrderValue { get; set; }

        private OrderDirection OrderDirection { get; set; }

        private int? AfterOrderValue => OrderValue.HasValue ? StockValue + (OrderDirection == OrderDirection.Buy ? OrderValue : -OrderValue) : null;

        private async Task HandleBuySellButton(OrderDirection newPosition)
        {
            OrderDirection = newPosition;
            await HandleOrderChange(OrderValue.HasValue ? new Value(OrderValue.Value) : new None());
        }

        private async Task HandleQuantityChange(ChangeEventArgs changeEventArgs)
        {
            var newQuantity = changeEventArgs.GetDouble();
            await HandleOrderChange (new Quantity(newQuantity));
        }

        private async Task HandleValueChange(ChangeEventArgs changeEventArgs)
        {
            var newValue = changeEventArgs.GetInt();
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
                    OrderQuantity = value.Amount.HasValue ? Math.Round(value.Amount.Value / StockPrice, 2) : null;
                },
                quantity =>
                {
                    OrderQuantity = quantity.Amount.HasValue ? Math.Round(quantity.Amount.Value, 2) : null;
                    OrderValue = (int?)(quantity.Amount * StockPrice);
                },
                none =>
                {
                    OrderQuantity = null;
                    OrderValue = null;
                }
                );

            await OnStockSelectionChanged.InvokeAsync(AfterOrderValue);
        }

        private record Quantity(double? Amount);

        private record Value(int? Amount);
    }
}
