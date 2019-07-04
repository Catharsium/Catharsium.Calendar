using System.Collections.Generic;

namespace Catharsium.Calendar.Core.Entities.Models
{
    public class RemindersList
    {
        public virtual IList<Reminder> Overrides { get; set; }
        public virtual bool? UseDefault { get; set; }
    }
}