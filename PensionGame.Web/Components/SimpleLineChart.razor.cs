using ChartJs.Blazor.Common;
using ChartJs.Blazor.Common.Axes;
using ChartJs.Blazor.Common.Axes.Ticks;
using ChartJs.Blazor.Common.Enums;
using ChartJs.Blazor.LineChart;
using ChartJs.Blazor.Util;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace PensionGame.Web.Components
{
    public partial class SimpleLineChart
    {
        [Parameter]
        public string Title { get; set; } = string.Empty;

        [Parameter]
        public string Label { get; set; } = string.Empty;

        [Parameter]
        public string XLabel { get; set; } = string.Empty;

        [Parameter]
        public string YLabel { get; set; } = string.Empty;

        [Parameter]
        public IReadOnlyCollection<decimal> Data { get; set; } = new List<decimal>();

        [Parameter]
        public IReadOnlyCollection<string> DataLabels { get; set; } = new List<string>();


        private LineConfig? Config { get; set; }

        protected override void OnInitialized()
        {
            Config = new()
            {
                Options = new LineOptions
                {
                    Scales = new Scales
                    {
                        XAxes = new List<CartesianAxis>
                    {
                        new CategoryAxis
                        {
                            ScaleLabel = new ScaleLabel
                            {
                                LabelString = XLabel
                            }
                        }
                    },
                        YAxes = new List<CartesianAxis>
                    {
                        new LinearCartesianAxis
                        {
                            ScaleLabel = new ScaleLabel
                            {
                                LabelString = YLabel
                            },
                            Ticks = new LinearCartesianTicks
                            {
                                BeginAtZero = true
                            }
                        }
                    }
                    },
                    Tooltips = new Tooltips
                    {
                        Mode = InteractionMode.Nearest,
                        Intersect = true
                    },
                    Responsive = true,
                    Title = new OptionsTitle
                    {
                        Display = true,
                        Text = Title
                    }
                }
            };

            foreach (var dataLabel in DataLabels)
            {
                Config.Data.Labels.Add(dataLabel);
            }

            var dataset = new LineDataset<decimal>(Data)
            {
                Label = Label,
                BorderColor = ColorUtil.ColorHexString(59, 125, 221),
                BackgroundColor = ColorUtil.ColorHexString(59, 125, 221),
                Fill = FillingMode.Disabled
            };

            Config.Data.Datasets.Add(dataset);
        }
    }
}
