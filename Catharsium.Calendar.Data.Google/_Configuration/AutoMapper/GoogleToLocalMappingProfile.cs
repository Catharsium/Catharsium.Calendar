using AutoMapper;
using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.Data.Google._Configuration.AutoMapper.Mappers;
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

namespace Catharsium.Calendar.Data.Google._Configuration.AutoMapper
{
    public class GoogleToLocalMappingProfile : Profile
    {
        public GoogleToLocalMappingProfile()
        {
            this.CreateMap<GoogleCalendarList, Core.Entities.Models.Calendar>();

            this.CreateMap<GoogleEvent, Event>()
                .ForMember(d => d.RemindersList, opt => opt.MapFrom(o => o.Reminders))
                .ForMember(d => d.CalendarId, opt => opt.Ignore());

            this.CreateMap<GoogleDateTime, Date>()
                .ForMember(d => d.Value, opt => opt.MapFrom<DateMapper>());

            this.CreateMap<GoogleRemindersList, RemindersList>();
            this.CreateMap<GoogleReminder, Reminder>();
            this.CreateMap<GoogleCreatorData, Person>();
            this.CreateMap<GoogleOrganizer, Person>();
            this.CreateMap<GoogleAttendee, Attendee>();
            this.CreateMap<GoogleSource, Source>();
            this.CreateMap<EventAttachment, Attachment>();
        }
    }
}