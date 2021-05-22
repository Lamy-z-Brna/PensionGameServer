using ChartJs.Blazor.Common;
using ChartJs.Blazor.Common.Enums;
using ChartJs.Blazor.PieChart;
using ChartJs.Blazor.Util;
using Microsoft.AspNetCore.Components;
using PensionGame.Web.Helpers;
using System.Collections.Generic;

namespace PensionGame.Web.Components
{
    public partial class SimplePieChart
    {
        [Parameter]
        public string Title { get; set; } = string.Empty;

        [Parameter]
        public IReadOnlyCollection<decimal> Data { get; set; } = new List<decimal>();

        [Parameter]
        public IReadOnlyCollection<string> DataLabels { get; set; } = new List<string>();


        private PieConfig? Config { get; set; }

        protected override void OnInitialized()
        {
            Config = new()
            {
                Options = new PieOptions
                {
                    Legend = new Legend
                    {
                        Position = Position.Bottom
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

            var dataset = new PieDataset<decimal>(Data)
            {
                BackgroundColor = new(new[]
                {
                    ColorUtil.FromDrawingColor(ColorHelper.Blue),
                    ColorUtil.FromDrawingColor(ColorHelper.Green),
                    ColorUtil.FromDrawingColor(ColorHelper.Yellow),
                    ColorUtil.FromDrawingColor(ColorHelper.Red),
                })
            };

            Config.Data.Datasets.Add(dataset);
        }
    }
}
