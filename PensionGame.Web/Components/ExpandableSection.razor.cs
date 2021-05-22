using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PensionGame.Web.Components
{
    public partial class ExpandableSection
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }
        //[Parameter]
        public bool Collapsed { get; set; } = true;

        void Toggle()
        {
            Collapsed = !Collapsed;
        }
    }
}
