using AutoMapper;
using Catharsium.Calendar.Core.Entities.Models;
using Google.Apis.Calendar.v3.Data;
using Event = Catharsium.Calendar.Core.Entities.Models.Event;
using GoogleAttendee = Google.Apis.Calendar.v3.Data.EventAttendee;
using GoogleCalendarList = Google.Apis.Calendar.v3.Data.CalendarListEntry;
using GoogleCreatorData = Google.Apis.Calendar.v3.Data.Event.CreatorData;
using GoogleDateTime = Google.Apis.Calendar.v3.Data.EventDateTime;
using GoogleEvent = Google.Apis.Calendar.v3.Data.Event;
using GoogleOrganizer = Google.Apis.Calendar.v3.Data.Event.OrganizerData;
using GoogleReminder = Google.Apis.Calendar.v3.Data.EventReminder;
using GoogleRemindersList = Google.Apis.Calendar.v3.Data.Event.RemindersData;
using GoogleSource = Google.Apis.Calendar.v3.Data.Event.SourceData;

namespace Catharsium.Calendar.Google._Configuration.AutoMapper
{
    public class LocalToGoogleMappingProfile : Profile
    {
        public LocalToGoogleMappingProfile()
        {
            this.CreateMap<Core.Entities.Models.Calendar, GoogleCalendarList>();

            this.CreateMap<Event, GoogleEvent>()
            .ForMember(d => d.Reminders, opt => opt.MapFrom(o => o.RemindersList));
            //.ForMember(d => d.CalendarId, opt => opt.Ignore());

            this.CreateMap<Date, GoogleDateTime>()
                .ForMember(d => d.DateTime, opt => opt.MapFrom(o => o.Value))
                .ForMember(d => d.DateTimeRaw, opt => opt.MapFrom(o => o.Value.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ")));

            this.CreateMap<RemindersList, GoogleRemindersList>();
            this.CreateMap<Reminder, GoogleReminder>();
            this.CreateMap<Person, GoogleCreatorData>();
            this.CreateMap<Person, GoogleOrganizer>();
            this.CreateMap<Attendee, GoogleAttendee>();
            this.CreateMap<Source, GoogleSource>();
            this.CreateMap<Attachment, EventAttachment>();
        }
    }
}
