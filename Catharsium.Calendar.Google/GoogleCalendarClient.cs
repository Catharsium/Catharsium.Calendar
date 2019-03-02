using Catharsium.Calendar.Google.Core.Entities.Interfaces;
using Catharsium.Calendar.Google.Entities.Interfaces;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using System;

namespace Catharsium.Calendar.Google
{
    public class GoogleCalendarClient : IGoogleCalendarClient
    {
        private CalendarService CalendarService { get; }
        private readonly string calendarId;


        public GoogleCalendarClient(IGoogleCalendarServiceFactory serviceFactory, string calendarId)
        {
            this.CalendarService = serviceFactory.CreateService();
            this.calendarId = calendarId;
        }


        public CalendarList GetCalendars()
        {
            var request = this.CalendarService.CalendarList.List();
            return request.Execute();
        }


        public Event CreateEvent(string summary, DateTime start, DateTime end)
        {
            var events = new Event {
                Summary = summary,
                Start = new EventDateTime { DateTime = start },
                End = new EventDateTime { DateTime = end }
            };
            var request = this.CalendarService.Events.Insert(events, this.calendarId);
            return request.Execute();
        }


        public Events GetEvents()
        {
            var request = this.CalendarService.Events.List(this.calendarId);
            request.TimeMin = DateTime.Now;
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.MaxResults = 10;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            return request.Execute();
        }
    }
}