using ChartJs.Blazor.BarChart;
using ChartJs.Blazor.BarChart.Axes;
using ChartJs.Blazor.Common;
using ChartJs.Blazor.Common.Axes;
using ChartJs.Blazor.Common.Axes.Ticks;
using ChartJs.Blazor.Common.Enums;
using ChartJs.Blazor.Util;
using Microsoft.AspNetCore.Components;
using PensionGame.Api.Domain.Resources.Holdings;
using System.Collections.Generic;
using System.Linq;
using PensionGame.Web.Helpers;

namespace PensionGame.Web.Components
{
    public partial class ClientHoldingsChart
    {
        [Parameter]
        public Dictionary<int, ClientHoldings>? ClientHoldingsHistory { get; set; }

        [Parameter]
        public string? Title { get; set; }

        private BarConfig? Config { get; set; }

        protected override void OnInitialized()
        {
            if (ClientHoldingsHistory == null)
                return;

            Config = new()
            {
                Options = new BarOptions
                {
                    Responsive = true,
                    Legend = new Legend
                    {
                        Position = Position.Bottom
                    },
                    Title = new OptionsTitle
                    {
                        Display = Title != null,
                        Text = Title ?? string.Empty
                    },
                    Scales = new BarScales
                    {
                        XAxes = new List<CartesianAxis>
                        {
                            new BarCategoryAxis
                            {
                                ScaleLabel = new ScaleLabel
                                {
                                    LabelString = "Your Age"
                                },
                                Stacked = true
                            }
                        },
                        YAxes = new List<CartesianAxis>
                        {
                            new BarLinearCartesianAxis
                            {
                                Stacked = true,
                                Ticks = new LinearCartesianTicks
                                {
                                    BeginAtZero = true
                                }
                            }
                        }
                    }
                }
            };            

            foreach (var dataLabel in ClientHoldingsHistory.Keys)
            {
                Config.Data.Labels.Add(dataLabel.ToString());
            }

            var stockData = new BarDataset<int>(ClientHoldingsHistory.Values.Select(holding => holding.Stocks.Value))
            {
                Label = "Stock holdings",
                BackgroundColor = ColorUtil.FromDrawingColor(ColorHelper.Blue),
                BorderColor = ColorUtil.FromDrawingColor(ColorHelper.Blue),
                BorderWidth = 1
            };

            var bondData = new BarDataset<int>(ClientHoldingsHistory.Values.Select(holding => holding.Bonds.Value))
            {
                Label = "Bond holdings",
                BackgroundColor = ColorUtil.FromDrawingColor(ColorHelper.Green),
                BorderColor = ColorUtil.FromDrawingColor(ColorHelper.Green),
                BorderWidth = 1
            };

            var savingsAccountData = new BarDataset<int>(ClientHoldingsHistory.Values.Select(holding => holding.SavingsAccount.Amount))
            {
                Label = "Savings account holdings",
                BackgroundColor = ColorUtil.FromDrawingColor(ColorHelper.Yellow),
                BorderColor = ColorUtil.FromDrawingColor(ColorHelper.Yellow),
                BorderWidth = 1
            };

            var loanData = new BarDataset<int>(ClientHoldingsHistory.Values.Select(holding => -holding.Loans.TotalLoanValue))
            {
                Label = "Loans",
                BackgroundColor = ColorUtil.FromDrawingColor(ColorHelper.Red),
                BorderColor = ColorUtil.FromDrawingColor(ColorHelper.Red),
                BorderWidth = 1
            };

            Config.Data.Datasets.Add(stockData);
            Config.Data.Datasets.Add(bondData);
            Config.Data.Datasets.Add(savingsAccountData);
            Config.Data.Datasets.Add(loanData);
        }
    }
}
