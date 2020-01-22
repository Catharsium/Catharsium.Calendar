using Catharsium.Calendar.Core.Entities.Interfaces.Services;
using Catharsium.Calendar.Core.Logic.Interfaces;
using Catharsium.Util.IO.Interfaces;
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
        private readonly IConsole console;


        public CalendarImporter(
            ICalendarService calendarService,
            IEventManagementService eventService, 
            ICalendarStorage calendarStorage,
            IConsole console)
        {
            this.calendarService = calendarService;
            this.eventService = eventService;
            this.calendarStorage = calendarStorage;
            this.console = console;
        }


        public void Import(string calendarId, DateTime startDate, DateTime endDate)
        {
            var calendar = this.calendarService.Get(calendarId);
            while (startDate < endDate) {
                var queryEndDate = startDate.AddMonths(1);
                this.console.WriteLine($"Period: {startDate:yyyy-MM-dd} - {queryEndDate:yyyy-MM-dd}");
                var events = this.eventService.GetList(calendar.Id, startDate, queryEndDate).ToList();
                this.console.WriteLine($"Found {events.Count} events in {calendar.Summary}");

                var fileName = $"{calendar.Summary}, {startDate:yyyy-MM-dd} {queryEndDate:yyyy-MM-dd}";
                if (events.Any()) {
                    this.calendarStorage.Store(events, fileName);
                    this.console.WriteLine($"Stored in {fileName}");
                    Thread.Sleep(100);
                }

                this.console.WriteLine();
                startDate = queryEndDate;
            }
        }
    }
}