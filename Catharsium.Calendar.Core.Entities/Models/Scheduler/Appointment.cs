using System;

namespace Catharsium.Calendar.Core.Entities.Models.Scheduler
{
    public class Appointment
    {
        public string CalendarId { get; set; }
        public string Summary { get; set; }
        public string Location { get; set; }
        public TimeSpan StartTime { get; set; }
        public int DurationInMinutes { get; set; }
        public string Category { get; set; }
        public string Recurrence { get; set; }
    }
}