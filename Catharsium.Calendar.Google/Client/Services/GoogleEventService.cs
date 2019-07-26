using AutoMapper;
using Catharsium.Calendar.Core.Entities.Interfaces;
using Catharsium.Calendar.Core.Entities.Models;
using Google.Apis.Calendar.v3;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using GoogleEvent = Google.Apis.Calendar.v3.Data.Event;

namespace Catharsium.Calendar.Google.Client.Services
{
    [ExcludeFromCodeCoverage]
    public class GoogleEventService : IEventService
    {
        private readonly ICalendarClientFactory calendarClientFactory;
        private readonly IMapper mapper;


        public GoogleEventService(ICalendarClientFactory calendarClientFactory, IMapper mapper)
        {
            this.calendarClientFactory = calendarClientFactory;
            this.mapper = mapper;
        }


        public IEnumerable<Event> GetList(string calendarId, DateTime from, DateTime to)
        {
            var calendarService = this.calendarClientFactory.Get();
            var request = calendarService.Events.List(calendarId);
            request.TimeMin = from;
            request.TimeMax = to;
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.MaxResults = 2500;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;
            var result = request.Execute();
            return result.Items.Select(e =>
            {
                var @event = this.mapper.Map<Event>(e);
                @event.CalendarId = calendarId;
                return @event;
            });
        }


        public Event GetEvent(string calendarId, string eventId)
        {
            var calendarService = this.calendarClientFactory.Get();
            var request = calendarService.Events.Get(calendarId, eventId);
            var result = this.mapper.Map<Event>(request.Execute());
            result.CalendarId = calendarId;
            return result;
        }


        public Event CreateEvent(string calendarId, Event eventData)
        {
            var calendarService = this.calendarClientFactory.Get();
            var googleEvent = this.mapper.Map<GoogleEvent>(eventData);
            var request = calendarService.Events.Insert(googleEvent, calendarId);
            var result = this.mapper.Map<Event>(request.Execute());
            result.CalendarId = calendarId;
            return result;
        }


        public void UpdateEvent(string calendarId, Event eventData)
        {
            var calendarService = this.calendarClientFactory.Get();
            var googleEvent = this.mapper.Map<GoogleEvent>(eventData);
            var request = calendarService.Events.Update(googleEvent, calendarId, eventData.Id);
            request.Execute();
        }


        public void DeleteEvent(string calendarId, string eventId)
        {
            var calendarService = this.calendarClientFactory.Get();
            var request = calendarService.Events.Delete(calendarId, eventId);
            request.Execute();
        }
    }
}