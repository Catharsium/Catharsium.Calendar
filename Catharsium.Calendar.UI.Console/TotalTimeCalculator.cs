using Catharsium.Clients.GoogleCalendar.Models;
using Catharsium.Util.Time.Extensions;
using System.Collections.Generic;

namespace Catharsium.Calendar.UI.Console
{
    public class TotalTimeCalculator
    {
        public static string CalculateTotalTime(IEnumerable<Event> filteredEvents)
        {
            var time = filteredEvents.Sum(e => e.End.Value - e.Start.Value);
            var days = time.Days != 0 ? $"{time.Days} days, " : "";
            var hours = $"{time.Hours} hours";
            var minutes = time.Minutes != 0 ? $", {time.Minutes} minutes" : "";
            return $"{days}{hours}{minutes}";
        }
    }
}