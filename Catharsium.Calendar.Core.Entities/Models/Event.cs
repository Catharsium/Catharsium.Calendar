using Catharsium.Calendar.Core.Entities.Models.Enums;
using Catharsium.Util.Enums;
using System;
using System.Collections.Generic;

namespace Catharsium.Calendar.Core.Entities.Models
{
    public class Event
    {
        public virtual string Id { get; set; }
        public virtual string CalendarId { get; set; }
        public virtual string ICalUID { get; set; }
        public virtual string RecurringEventId { get; set; }
        public virtual string ETag { get; set; }
        public virtual string HtmlLink { get; set; }

        public virtual Date OriginalStartTime { get; set; }
        public virtual Date Start { get; set; }
        public virtual Date End { get; set; }
        public virtual IList<string> Recurrence { get; set; }

        public virtual string Summary { get; set; }
        public virtual string Description { get; set; }
        public virtual string Location { get; set; }
        public virtual bool? Locked { get; set; }
        public virtual Person Organizer { get; set; }
        public virtual IList<Attendee> Attendees { get; set; }
        public virtual IList<Attachment> Attachments { get; set; }
        public virtual RemindersList RemindersList { get; set; }

        public virtual Person Creator { get; set; }
        public virtual DateTime? Created { get; set; }
        public virtual DateTime? Updated { get; set; }
        public virtual Source Source { get; set; }

        public virtual bool? PrivateCopy { get; set; }
        public virtual int? Sequence { get; set; }
        public virtual string Status { get; set; }
        public virtual string Transparency { get; set; }
        public virtual string Visibility { get; set; }
        public virtual string Kind { get; set; }
        public virtual bool? AttendeesOmitted { get; set; }
        public virtual string ColorId { get; set; }

        public virtual bool? AnyoneCanAddSelf { get; set; }
        public virtual bool? GuestsCanInviteOthers { get; set; }
        public virtual bool? GuestsCanModify { get; set; }
        public virtual bool? GuestsCanSeeOtherGuests { get; set; }

        public Category Category
        {
            get {
                if (this.ColorId == null) { return Category.Unknown; }

                var category = this.ColorId.ParseTo<Category>();
                return category ?? Category.Unknown;
            }
        }
    }
}