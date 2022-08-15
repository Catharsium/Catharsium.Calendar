using Catharsium.Calendar.Core.Logic.Interfaces;
using Catharsium.External.GoogleCalendar.Client.Interfaces;
using Catharsium.External.GoogleCalendar.Client.Models;
using Catharsium.Util.IO.Console.Interfaces;
using Catharsium.Util.IO.Interfaces;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Catharsium.Calendar.Core.Logic.Storage;

public class CalendarImporter : ICalendarImporter
{
    private readonly IGoogleCalendarService googleCalendarService;
    private readonly IEventManagementService eventService;
    private readonly IJsonFileRepository<Event> jsonFileRepository;
    private readonly IConsole console;


    public CalendarImporter(
        IGoogleCalendarService googleCalendarService,
        IEventManagementService eventService,
        IJsonFileRepository<Event> jsonFileRepository,
        IConsole console) {
        this.googleCalendarService = googleCalendarService;
        this.eventService = eventService;
        this.jsonFileRepository = jsonFileRepository;
        this.console = console;
    }


    public async Task Import(string calendarId, DateTime startDate, DateTime endDate) {
        var calendar = await this.googleCalendarService.Get(calendarId);
        while (startDate < endDate) {
            var queryEndDate = startDate.AddMonths(1);
            this.console.WriteLine($"Period: {startDate:yyyy-MM-dd} - {queryEndDate:yyyy-MM-dd}");
            var events = (await this.eventService.GetList(calendar.Id, startDate, queryEndDate)).ToList();
            this.console.WriteLine($"Found {events.Count} events in {calendar.Summary}");

            var fileName = $"{calendar.Summary}, {startDate:yyyy-MM-dd} {queryEndDate:yyyy-MM-dd}";
            if (events.Any()) {
                await this.jsonFileRepository.Store(events, fileName);
                this.console.WriteLine($"Stored in {fileName}");
            }

            this.console.WriteLine();
            startDate = queryEndDate;
            Thread.Sleep(1000);
        }
    }
}