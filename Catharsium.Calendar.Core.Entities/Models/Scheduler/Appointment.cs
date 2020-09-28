using System;

namespace Catharsium.Calendar.Core.Entities.Models.Scheduler
{
    public class Appointment
    {
        public string CalendarId { get; set; }
        public string Summary { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Recurrence Recurrence { get; set; }
    }
}