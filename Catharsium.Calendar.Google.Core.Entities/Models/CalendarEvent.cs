using System;

namespace Catharsium.Calendar.Google.Core.Entities.Models
{
    public class CalendarEvent
    {
        public string Summary { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }
    }
}