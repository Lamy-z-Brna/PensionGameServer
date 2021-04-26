using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PensionGame.Web.Components
{
    public partial class LoadingOverlay
    {
        [Parameter]
        public bool IsLoading { get; set; }
    }
}
