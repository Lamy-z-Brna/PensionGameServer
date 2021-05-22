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

namespace PensionGame.Web.Components
{
    public partial class ClientHoldingsChart
    {
        [Parameter]
        public Dictionary<int, ClientHoldings> ClientHoldingsHistory { get; set; } = new();

        private BarConfig Config { get; } = new()
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
                    Display = true,
                    Text = "Your holdings performance"
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

        protected override void OnInitialized()
        {           
            foreach (var dataLabel in ClientHoldingsHistory.Keys)
            {
                Config.Data.Labels.Add(dataLabel.ToString());
            }

            var stockData = new BarDataset<int>(ClientHoldingsHistory.Values.Select(holding => holding.Stocks.Value))
            {
                Label = "Stock holdings",
                BackgroundColor = ColorUtil.ColorHexString(59, 125, 221),
                BorderColor = ColorUtil.ColorHexString(59, 125, 221),
                BorderWidth = 1
            };

            var bondData = new BarDataset<int>(ClientHoldingsHistory.Values.Select(holding => holding.Bonds.Value))
            {
                Label = "Bond holdings",
                BackgroundColor = ColorUtil.ColorHexString(40, 167, 69),
                BorderColor = ColorUtil.ColorHexString(40, 167, 69),
                BorderWidth = 1
            };

            var savingsAccountData = new BarDataset<int>(ClientHoldingsHistory.Values.Select(holding => holding.SavingsAccount.Amount))
            {
                Label = "Savings account holdings",
                BackgroundColor = ColorUtil.ColorHexString(255, 193, 7),
                BorderColor = ColorUtil.ColorHexString(255, 193, 7),
                BorderWidth = 1
            };

            var loanData = new BarDataset<int>(ClientHoldingsHistory.Values.Select(holding => -holding.Loans.TotalLoanValue))
            {
                Label = "Loans",
                BackgroundColor = ColorUtil.ColorHexString(220, 53, 69),
                BorderColor = ColorUtil.ColorHexString(220, 53, 69),
                BorderWidth = 1
            };

            Config.Data.Datasets.Add(stockData);
            Config.Data.Datasets.Add(bondData);
            Config.Data.Datasets.Add(savingsAccountData);
            Config.Data.Datasets.Add(loanData);
        }
    }
}
