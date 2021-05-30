using Microsoft.AspNetCore.Components;
using System.Globalization;

namespace PensionGame.Web.Helpers
{
    public static class ChangeEventArgsHelper
    {
        public static double? GetDouble(this ChangeEventArgs changeEventArgs)
        {
            if (changeEventArgs.Value is not string text)
                return null;

            _ = double.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out var result);

            return result;
        }

        public static int? GetInt(this ChangeEventArgs changeEventArgs)
        {
            if (changeEventArgs.Value is not string text)
                return null;

            _ = int.TryParse(text, out var result);

            return result;
        }
    }
}
