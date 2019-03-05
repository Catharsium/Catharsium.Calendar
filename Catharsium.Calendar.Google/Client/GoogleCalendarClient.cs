using System;
using AutoMapper;
using Catharsium.Calendar.Core.Entities.Interfaces;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;

namespace Catharsium.Calendar.Google.Client
{
    public class GoogleCalendarClient : ICalendarClient
    {
        private readonly CalendarService calendarService;
        private readonly IMapper mapper;


        public GoogleCalendarClient(ICalendarClientFactory clientFactory, IMapper mapper)
        {
            this.calendarService = clientFactory.CreateClient();
            this.mapper = mapper;
        }


        public Event CreateEvent(string calendarId, string summary, DateTime start, DateTime end)
        {
            var events = new Event {
                Summary = summary,
                Start = new EventDateTime { DateTime = start },
                End = new EventDateTime { DateTime = end }
            };
            var request = this.calendarService.Events.Insert(events, calendarId);
            return request.Execute();
        }
    }
}