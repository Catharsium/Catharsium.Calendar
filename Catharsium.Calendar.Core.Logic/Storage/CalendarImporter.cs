using Catharsium.Calendar.Core.Entities.Interfaces.Services;
using Catharsium.Calendar.Core.Logic.Interfaces;
using System;
using System.Linq;
using System.Threading;

namespace Catharsium.Calendar.Core.Logic.Storage
{
    public class CalendarImporter : ICalendarImporter
    {
        private readonly ICalendarService calendarService;
        private readonly IEventManagementService eventService;
        private readonly ICalendarStorage calendarStorage;


        public CalendarImporter(ICalendarService calendarService, IEventManagementService eventService, ICalendarStorage calendarStorage)
        {
            this.calendarService = calendarService;
            this.eventService = eventService;
            this.calendarStorage = calendarStorage;
        }


        public void Import(string calendarId, DateTime startDate, DateTime endDate)
        {
            var calendar = this.calendarService.Get(calendarId);
            while (startDate < endDate)
            {
                var queryEndDate = startDate.AddMonths(1);
                Console.WriteLine($"Period: {startDate:yyyy-MM-dd} - {queryEndDate:yyyy-MM-dd}");
                var events = this.eventService.GetList(calendar.Id, startDate, queryEndDate).ToList();
                Console.WriteLine($"Found {events.Count} events in {calendar.Summary}");

                var fileName = $"{calendar.Summary}, {startDate:yyyy-MM-dd} {queryEndDate:yyyy-MM-dd}";
                if (events.Any())
                {
                    this.calendarStorage.Store(events, fileName);
                    Console.WriteLine($"Stored in {fileName}");
                    Thread.Sleep(100);
                }

                Console.WriteLine();
                startDate = queryEndDate;
            }
        }
    }
}