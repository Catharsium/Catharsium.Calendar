using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using System;

namespace Catharsium.Calendar.Google
{
    public class GoogleCalendarClient : IGoogleCalendarClient
    {
        private CalendarService CalendarService { get; }


        public GoogleCalendarClient(IGoogleCalendarServiceFactory serviceFactory)
        {
            CalendarService = serviceFactory.CreateService();
        }


        public Event CreateEvent(string summary, DateTime start, DateTime end)
        {
            var events = new Event {
                Summary = summary,
                Start = new EventDateTime { DateTime = start },
                End = new EventDateTime { DateTime = end }
            };
            var request = CalendarService.Events.Insert(events, "primary");
            return request.Execute();
        }

        
        public Events GetEvents()
        {
            var request = CalendarService.Events.List("primary");
            request.TimeMin = DateTime.Now;
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.MaxResults = 10;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            return request.Execute();
        }
    }
}