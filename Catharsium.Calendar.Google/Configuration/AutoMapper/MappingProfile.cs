using System;
using AutoMapper;
using Catharsium.Calendar.Core.Entities.Models;
using Google.Apis.Calendar.v3.Data;
using GoogleEvent = Google.Apis.Calendar.v3.Data.Event;

namespace Catharsium.Calendar.Google.Configuration.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<CalendarListEntry, Core.Entities.Models.Calendar>();

            this.CreateMap<GoogleEvent, Core.Entities.Models.Event>();

            this.CreateMap<EventDateTime, Date>()
                .ForMember(d => d.HasTime, opt => opt.MapFrom(o => o.DateTime.HasValue))
                .ForMember(d => d.Value, opt => opt.MapFrom(o => o.DateTime.HasValue ? o.DateTime : DateTime.Parse(o.Date)));
        }
    }
}