using System;

namespace PensionGame.Web.Helpers
{
    public static class DateTimeExtensions
    {
        public static string ToStringRelative(this DateTime dateTime)
        {
            var now = DateTime.Now;
            var timeSpan = now > dateTime ? now.Subtract(dateTime) : dateTime.Subtract(now);

            if (timeSpan.TotalSeconds < 1)
            {
                return "now";
            }

            string durationText;
            if (timeSpan.TotalSeconds < 2)
            {
                durationText = "a second";
            }
            else if (timeSpan.TotalSeconds < 60)
            {
                durationText = $"{timeSpan.Seconds} seconds";
            }
            else if (timeSpan.TotalMinutes < 2)
            {
                durationText = "a minute";
            }
            else if (timeSpan.TotalMinutes < 60)
            {
                durationText = $"{timeSpan.Minutes} minutes";
            }
            else if (timeSpan.TotalHours < 2)
            {
                durationText = "an hour";
            }
            else if (timeSpan.TotalHours < 24)
            {
                durationText = $"{timeSpan.Hours} hours";
            }
            else if (timeSpan.TotalDays < 2)
            {
                durationText = "a day";
            }
            else if (timeSpan.TotalDays < 30)
            {
                durationText = $"{timeSpan.Days} days";
            }
            else if (timeSpan.TotalDays < 60)
            {
                durationText = "a month";
            }
            else if (timeSpan.TotalDays < 365)
            {
                durationText = $"{timeSpan.Days / 30} months";
            }
            else if (timeSpan.TotalDays < 730)
            {
                durationText = "a year";
            }
            else
            {
                durationText = $"{timeSpan.Days / 365} years";
            }

            return now > dateTime ? $"{durationText} ago" : $"in {durationText}";
        }
    }
}
