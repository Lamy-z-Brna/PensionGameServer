using System;

namespace PensionGame.Core.Common
{
    public static class Rounder
    {
        public static int Round(double value)
        {
            return (int)value.ToRound(0);
        }

        public static double ToRound(this double value)
        {
            return value.ToRound(3);
        }

        public static double ToRound(this double value, int precision)
        {
            return Math.Round(value, precision);
        }
    }
}
