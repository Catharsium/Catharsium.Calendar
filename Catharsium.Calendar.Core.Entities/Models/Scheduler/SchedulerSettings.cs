using System.Collections.Generic;

namespace Catharsium.Calendar.Core.Entities.Models.Scheduler
{
    public class SchedulerSettings
    {
        public List<Appointment> Appointments { get; set; }
        public List<Template> Templates { get; set; }
    }
}