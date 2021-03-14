using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionGame.Core.Common
{
    public static class Rounder
    {
        public static int Round(double value)
        {
            return (int)Math.Round(value, 0);
        }
    }
}
