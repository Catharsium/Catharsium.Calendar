using Catharsium.Calendar.Core.Entities.Interfaces.Services;
using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.Core.Logic.Interfaces;
using Catharsium.Util.IO.Console.Interfaces;
using Catharsium.Util.IO.Interfaces;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Catharsium.Calendar.Core.Logic.Storage
{
    public class CalendarImporter : ICalendarImporter
    {
        private readonly ICalendarService calendarService;
        private readonly IEventManagementService eventService;
        private readonly IJsonFileRepository<Event> jsonFileRepository;
        private readonly IConsole console;


        public CalendarImporter(
            ICalendarService calendarService,
            IEventManagementService eventService,
            IJsonFileRepository<Event> jsonFileRepository,
            IConsole console)
        {
            this.calendarService = calendarService;
            this.eventService = eventService;
            this.jsonFileRepository = jsonFileRepository;
            this.console = console;
        }


        public async Task Import(string calendarId, DateTime startDate, DateTime endDate)
        {
            var calendar = await this.calendarService.Get(calendarId);
            while (startDate < endDate) {
                var queryEndDate = startDate.AddMonths(1);
                this.console.WriteLine($"Period: {startDate:yyyy-MM-dd} - {queryEndDate:yyyy-MM-dd}");
                var events = (await this.eventService.GetList(calendar.Id, startDate, queryEndDate)).ToList();
                this.console.WriteLine($"Found {events.Count} events in {calendar.Summary}");

                var fileName = $"{calendar.Summary}, {startDate:yyyy-MM-dd} {queryEndDate:yyyy-MM-dd}";
                if (events.Any()) {
                    await this.jsonFileRepository.Store(events, fileName);
                    this.console.WriteLine($"Stored in {fileName}");
                    Thread.Sleep(100);
                }

                this.console.WriteLine();
                startDate = queryEndDate;
            }
        }
    }
}