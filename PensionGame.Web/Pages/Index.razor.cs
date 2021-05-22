using System;
using System.Threading.Tasks;
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