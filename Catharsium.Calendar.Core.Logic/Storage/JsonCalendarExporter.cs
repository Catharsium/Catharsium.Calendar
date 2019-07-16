using Catharsium.Calendar.Core.Entities.Interfaces;
using Catharsium.Calendar.Core.Logic.Interfaces;
using System;
using System.Linq;

namespace Catharsium.Calendar.Core.Logic.Storage
{
    public class JsonCalendarExporter : ICalendarExporter
    {
        private readonly ICalendarService calendarService;
        private readonly IEventService eventService;
        private readonly IEventRepository eventRepository;


        public JsonCalendarExporter(ICalendarService calendarService, IEventService eventService, IEventRepository eventRepository)
        {
            this.calendarService = calendarService;
            this.eventService = eventService;
            this.eventRepository = eventRepository;
        }


        public void Export()
        {
            var calendars = this.calendarService.GetList().ToList();
            var startDate = new DateTime(2015, 1, 1);
            while (startDate < DateTime.Now) {
                var endDate = startDate.AddMonths(1);
                Console.WriteLine($"Period: {startDate:yyyy-MM-dd} - {endDate:yyyy-MM-dd}");
                foreach (var calendar in calendars) {
                    var events = this.eventService.GetList(calendar.Id, startDate, endDate).ToList();
                    Console.WriteLine($"Found {events.Count} events in {calendar.Summary}");
                    var fileName = $"{calendar.Summary}, {startDate:yyyy-MM-dd} {endDate:yyyy-MM-dd}";
                    if (events.Any()) {
                        this.eventRepository.Store(events, fileName);
                    }
                }

                Console.WriteLine();
                startDate = endDate;
            }
        }
    }
}