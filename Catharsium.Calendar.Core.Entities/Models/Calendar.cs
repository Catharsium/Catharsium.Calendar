using System.Collections.Generic;

namespace Catharsium.Calendar.Core.Entities.Models
{
    public class Calendar
    {
        public virtual string Id { get; set; }
        public virtual string ETag { get; set; }
        public virtual string Kind { get; set; }
        public virtual bool? Primary { get; set; }
        public virtual bool? Hidden { get; set; }
        public virtual bool? Deleted { get; set; }

        public virtual string Summary { get; set; }
        public virtual string Description { get; set; }
        public virtual string SummaryOverride { get; set; }

        public virtual IList<Notification> Notifications { get; set; }
        public virtual IList<Reminder> DefaultReminders { get; set; }
        public virtual string Location { get; set; }
        public virtual string TimeZone { get; set; }

        public virtual bool? Selected { get; set; }
        public virtual string ColorId { get; set; }
        public virtual string BackgroundColor { get; set; }
        public virtual string AccessRole { get; set; }
        public virtual string ForegroundColor { get; set; }
    }
}