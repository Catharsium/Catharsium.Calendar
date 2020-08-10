using System;
using System.Collections.Generic;
using System.Text;

namespace Catharsium.Calendar.Core.Entities.Models.Scheduler
{
    public class Schedule
    {
        public Frequency Frequency { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }


    public enum Frequency
    {
        Daily,
        Weekly,
        Monthly,
        Annually
    }
}
