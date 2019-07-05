using AutoMapper;
using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.Google._Configuration.AutoMapper.Mappers;
using GoogleCalendarList = Google.Apis.Calendar.v3.Data.CalendarListEntry;
using GoogleDateTime = Google.Apis.Calendar.v3.Data.EventDateTime;
using GoogleEvent = Google.Apis.Calendar.v3.Data.Event;
using GoogleOrganizer = Google.Apis.Calendar.v3.Data.Event.OrganizerData;
using GoogleRemindersList = Google.Apis.Calendar.v3.Data.Event.RemindersData;
using GoogleReminder = Google.Apis.Calendar.v3.Data.EventReminder;
using GoogleCreatorData = Google.Apis.Calendar.v3.Data.Event.CreatorData;
using GoogleAttendee = Google.Apis.Calendar.v3.Data.EventAttendee;

namespace Catharsium.Calendar.Google._Configuration.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<GoogleCalendarList, Core.Entities.Models.Calendar>();

            this.CreateMap<GoogleEvent, Event>()
                .ForMember(d => d.RemindersList, opt => opt.MapFrom(o => o.Reminders));

            this.CreateMap<GoogleDateTime, Date>()
                .ForMember(d => d.Value, opt => opt.MapFrom<DateMapper>());

            this.CreateMap<GoogleRemindersList, RemindersList>();
            this.CreateMap<GoogleReminder, Reminder>();

            this.CreateMap<GoogleCreatorData, Person>();
            this.CreateMap<GoogleOrganizer, Person>();
            this.CreateMap<GoogleAttendee, Attendee>();
        }
    }
}