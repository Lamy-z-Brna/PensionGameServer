using System;

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
