using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using PensionGame.Web.Components;

namespace PensionGame.Web.Pages
{
    public partial class Index
    {
        DateTime LastChange;
        BinaryButton? TradeButton;
        BinaryButton.Position Old;
        BinaryButton.Position New;

        private Task Change((BinaryButton.Position, BinaryButton.Position) positions)
        {
            LastChange = DateTime.Now;
            Old = positions.Item1;
            New = positions.Item2;
            return Task.CompletedTask;
        }
    }
}