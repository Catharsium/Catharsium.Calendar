using AutoMapper;
using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.Google._Configuration.AutoMapper.Mappers;
using GoogleCalendarList = Google.Apis.Calendar.v3.Data.CalendarListEntry;
using GoogleDateTime = Google.Apis.Calendar.v3.Data.EventDateTime;
using GoogleEvent = Google.Apis.Calendar.v3.Data.Event;
using GoogleOrganizer = Google.Apis.Calendar.v3.Data.Event.OrganizerData;
using GoogleRemindersList = Google.Apis.Calendar.v3.Data.Event.RemindersData;
using GoogleReminder = Google.Apis.Calendar.v3.Data.EventReminder;

namespace Catharsium.Calendar.Google._Configuration.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<GoogleCalendarList, Core.Entities.Models.Calendar>();

            this.CreateMap<GoogleEvent, Event>();

            this.CreateMap<GoogleDateTime, Date>()
                .ForMember(d => d.Value, opt => opt.MapFrom<DateMapper>());

            this.CreateMap<GoogleRemindersList, Reminders>();
            this.CreateMap<GoogleReminder, Reminder>();

            this.CreateMap<GoogleOrganizer, Person>();
        }
    }
}