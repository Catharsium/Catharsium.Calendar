using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using System;

namespace Catharsium.Calendar.Google
{
    public class GoogleCalendarClient
    {
        private CalendarService CalendarService { get; }


        public GoogleCalendarClient(GoogleCalendarServiceFactory serviceFactory)
        {
            CalendarService = serviceFactory.CreateService();
        }


        public Event CreateEvent()
        {
            var events = new Event {
                Start = new EventDateTime { DateTime = DateTime.Now.AddDays(1) },
                End = new EventDateTime { DateTime = DateTime.Now.AddDays(1).AddHours(1) },
                Summary = "Automatically generated event", 
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