using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PensionGame.Web.Components
{
    public partial class Tooltip
    {
        [Parameter] 
        public RenderFragment? ChildContent { get; set; }

        [Parameter] 
        public string? Text { get; set; }
    }
}
