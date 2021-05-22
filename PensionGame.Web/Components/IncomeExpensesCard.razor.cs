using Microsoft.AspNetCore.Components;
using PensionGame.Api.Domain.Resources.ClientData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PensionGame.Web.Components
{
    public partial class IncomeExpensesCard
    {
        [Parameter]
        public ClientData? ClientData { get; set; }

        [Parameter]
        public int DisposableIncome { get; set; }
    }
}
