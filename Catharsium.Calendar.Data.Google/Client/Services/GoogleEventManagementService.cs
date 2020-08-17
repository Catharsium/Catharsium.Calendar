using AutoMapper;
using Catharsium.Calendar.Core.Entities.Interfaces.Services;
using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.Data.Google.Interfaces;
using Google.Apis.Calendar.v3;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using GoogleEvent = Google.Apis.Calendar.v3.Data.Event;

namespace Catharsium.Calendar.Data.Google.Client.Services
{
    [ExcludeFromCodeCoverage]
    public class GoogleEventManagementService : IEventManagementService
    {
        private readonly ICalendarClientFactory calendarClientFactory;
        private readonly IMapper mapper;


        public GoogleEventManagementService(ICalendarClientFactory calendarClientFactory, IMapper mapper)
        {
            this.calendarClientFactory = calendarClientFactory;
            this.mapper = mapper;
        }


        public Task<IEnumerable<Event>> GetList(string calendarId, DateTime from, DateTime to)
        {
            var calendarService = this.calendarClientFactory.Get();
            var request = calendarService.Events.List(calendarId);
            request.TimeMin = from;
            request.TimeMax = to;
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.MaxResults = 2500;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;
            return Task.Run(() => {
                var result = request.Execute();
                return result.Items.Select(e => {
                    var @event = this.mapper.Map<Event>(e);
                    @event.CalendarId = calendarId;
                    return @event;
                });
            });
        }


        public Task<Event> GetEvent(string calendarId, string eventId)
        {
            return Task.Run(() => {
                    var calendarService = this.calendarClientFactory.Get();
                    var request = calendarService.Events.Get(calendarId, eventId);
                    var result = this.mapper.Map<Event>(request.Execute());
                    result.CalendarId = calendarId;
                    return result;
                }
            );
        }


        public Task<Event> CreateEvent(string calendarId, Event eventData)
        {
            var calendarService = this.calendarClientFactory.Get();
            var googleEvent = this.mapper.Map<GoogleEvent>(eventData);
            var request = calendarService.Events.Insert(googleEvent, calendarId);
            return Task.Run(() => {
                var result = this.mapper.Map<Event>(request.Execute());
                result.CalendarId = calendarId;
                return result;
            });
        }


        public Task UpdateEvent(string calendarId, Event eventData)
        {
            var calendarService = this.calendarClientFactory.Get();
            var googleEvent = this.mapper.Map<GoogleEvent>(eventData);
            var request = calendarService.Events.Update(googleEvent, calendarId, eventData.Id);
            return Task.Run(() => request.Execute());
        }


        public Task DeleteEvent(string calendarId, string eventId)
        {
            var calendarService = this.calendarClientFactory.Get();
            var request = calendarService.Events.Delete(calendarId, eventId);
            return Task.Run(() => request.Execute());
        }
    }
}