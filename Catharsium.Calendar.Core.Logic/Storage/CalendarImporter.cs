using Catharsium.Calendar.Core.Entities.Interfaces;
using Catharsium.Calendar.Core.Logic.Interfaces;
using System;
using System.Linq;

namespace Catharsium.Calendar.Core.Logic.Storage
{
    public class CalendarImporter : ICalendarImporter
    {
        private readonly ICalendarService calendarService;
        private readonly IEventService eventService;
        private readonly IEventRepository eventRepository;


        public CalendarImporter(ICalendarService calendarService, IEventService eventService, IEventRepository eventRepository)
        {
            this.calendarService = calendarService;
            this.eventService = eventService;
            this.eventRepository = eventRepository;
        }


        public void Import(string calendarId, DateTime startDate, DateTime endDate)
        {
            var calendar = this.calendarService.Get(calendarId);
            while (startDate < endDate) {
                var queryEndDate = startDate.AddMonths(1);
                Console.WriteLine($"Period: {startDate:yyyy-MM-dd} - {queryEndDate:yyyy-MM-dd}");
                var events = this.eventService.GetList(calendar.Id, startDate, queryEndDate).ToList();
                Console.WriteLine($"Found {events.Count} events in {calendar.Summary}");

                var fileName = $"{calendar.Summary}, {startDate:yyyy-MM-dd} {queryEndDate:yyyy-MM-dd}";
                if (events.Any()) {
                    this.eventRepository.Store(events, fileName);
                    Console.WriteLine($"Stored in {fileName}");
                }

                Console.WriteLine();
                startDate = queryEndDate;
            }
        }
    }
}