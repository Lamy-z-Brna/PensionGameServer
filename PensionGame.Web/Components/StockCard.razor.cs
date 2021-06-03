using Microsoft.AspNetCore.Components;
using PensionGame.Api.Domain.Resources.Holdings;
using System;
using System.Threading.Tasks;
using static PensionGame.Web.Components.BinaryButton;

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

        private OrderDirection Direction { get; set; }

        private int? AfterOrderValue => OrderValue.HasValue ? StockValue + (Direction == OrderDirection.Buy ? OrderValue : -OrderValue) : null;

        private async Task HandlePositionChange(Position position)
        {
            Direction = position == Position.Positive ? OrderDirection.Buy : OrderDirection.Sell;
            await HandleOrderChange(OrderValue);
        }

        private async Task HandleValueChange(int? orderValue)
        {
            await HandleOrderChange(orderValue);
        }

        private async Task HandleOrderChange(int? orderValue)
        {
            OrderValue = Direction == OrderDirection.Sell && orderValue > StockValue ? StockValue : orderValue;
            OrderQuantity = OrderValue.HasValue ? Math.Round(OrderValue.Value / StockPrice, 2) : null;

            await OnStockSelectionChanged.InvokeAsync(AfterOrderValue);
        }

        private enum OrderDirection
        {
            Buy,
            Sell
        }
    }
}
