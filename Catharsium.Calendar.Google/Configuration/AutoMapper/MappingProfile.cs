using AutoMapper;
using Google.Apis.Calendar.v3.Data;

namespace Catharsium.Calendar.Google.Configuration.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<CalendarListEntry, Core.Entities.Models.Calendar>();
            this.CreateMap<Event, Core.Entities.Models.Event>();
        }
    }
}