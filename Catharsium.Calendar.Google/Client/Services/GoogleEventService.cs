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
        private readonly CalendarService calendarService;
        private readonly IMapper mapper;


        public GoogleEventService(ICalendarClientFactory clientFactory, IMapper mapper)
        {
            this.calendarService = clientFactory.CreateClient();
            this.mapper = mapper;
        }


        public IEnumerable<Event> GetList(string calendarId, DateTime from, DateTime to)
        {
            var request = this.calendarService.Events.List(calendarId);
            request.TimeMin = from;
            request.TimeMax = to;
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.MaxResults = 2500;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;
            var result = request.Execute();
            return result.Items.Select(e => this.mapper.Map<Event>(e));
        }


        public Event GetEvent(string calendarId, string eventId)
        {
            var request = this.calendarService.Events.Get(calendarId, eventId);
            return this.mapper.Map<Event>(request.Execute());
        }


        public Event CreateEvent(string calendarId, Event eventData)
        {
            var googleEvent = this.mapper.Map<GoogleEvent>(eventData);
            var request = this.calendarService.Events.Insert(googleEvent, calendarId);
            return this.mapper.Map<Event>(request.Execute());
        }


        public void UpdateEvent(string calendarId, Event eventData)
        {
            var googleEvent = this.mapper.Map<GoogleEvent>(eventData);
            var request = this.calendarService.Events.Update(googleEvent, calendarId, eventData.Id);
            request.Execute();
        }


        public void DeleteEvent(string calendarId, string eventId)
        {
            var request = this.calendarService.Events.Delete(calendarId, eventId);
            request.Execute();
        }
    }
}