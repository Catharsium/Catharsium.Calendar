using System.Collections.Generic;

namespace Catharsium.Calendar.Google.Core.Entities.Models.Events
{
    public class Reminders
    {
        public virtual IList<Reminder> Overrides { get; set; }
        public virtual bool? UseDefault { get; set; }
    }
}