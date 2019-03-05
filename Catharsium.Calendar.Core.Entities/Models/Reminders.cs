using System.Collections.Generic;

namespace Catharsium.Calendar.Core.Entities.Models
{
    public class Reminders
    {
        public virtual IList<Reminder> Overrides { get; set; }
        public virtual bool? UseDefault { get; set; }
    }
}