using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Catharsium.Calendar.Core.Entities.Interfaces;
using Catharsium.Calendar.Core.Entities.Models;
using Google.Apis.Calendar.v3;

namespace Catharsium.Calendar.Google
{
    public class GoogleEventService : IEventService
    {
        private readonly CalendarService calendarService;
        private readonly IMapper mapper;


        public GoogleEventService(ICalendarClientFactory clientFactory, IMapper mapper)
        {
            this.calendarService = clientFactory.CreateClient();
            this.mapper = mapper;
        }


        public IEnumerable<Event> GetEvents(string calendarId)
        {
            var request = this.calendarService.Events.List(calendarId);
            request.TimeMin = DateTime.Now;
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.MaxResults = 10;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;
            var result = request.Execute();
            return result.Items.Select(e => this.mapper.Map<Event>(e));
        }
    }
}