using Microsoft.AspNetCore.Components;
using PensionGame.Web.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PensionGame.Web.Components
{
    public partial class Alert
    {
        [Parameter]
        public AlertType Type { get; set; }

        [Parameter]
        public string Title { get; set; } = string.Empty;

        [Parameter]
        public string DisplayMessage { get; set; } = string.Empty;
    }
}
