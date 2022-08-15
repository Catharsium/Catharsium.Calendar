using Catharsium.Calendar.Core.Logic.Interfaces;
using Catharsium.Calendar.UI.Console.Interfaces;
using Catharsium.Clients.GoogleCalendar.Interfaces;
using Catharsium.Clients.GoogleCalendar.Models;
using Catharsium.Util.IO.Console.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catharsium.Calendar.UI.Console.StepHandlers
{
    public class ShowEventsStepHandler : IShowEventsStepHandler
    {
        private readonly IConsole console;
        private readonly IGoogleCalendarService calendarService;
        private readonly IConsoleColorFactory consoleColorFactory;


        public ShowEventsStepHandler(IConsole console, IGoogleCalendarService calendarService, IConsoleColorFactory consoleColorFactory)
        {
            this.console = console;
            this.calendarService = calendarService;
            this.consoleColorFactory = consoleColorFactory;
        }


        public async Task ShowEvents(IEnumerable<Event> events)
        {
            var index = 0;
            foreach (var @event in events) {
                var when = @event.Start.Value.ToString("yyyy MMMM dd");
                if (@event.Start.HasTime) {
                    when += @event.Start.Value.ToString(" (HH:mm - ") + @event.End.Value.ToString("HH:mm)");
                }

                var calendars = await this.calendarService.GetList();
                var calendar = calendars.FirstOrDefault(c => c.Id == @event.CalendarId);
                var calendarName = calendar != null ? calendar.Summary : "";
                this.console.ForegroundColor = this.consoleColorFactory.GetById(@event.CalendarId, @event.ColorId);
                this.console.Write($"[{index + 1}]");
                this.SetColor(@event.CalendarId);
                this.console.WriteLine($" ({calendarName})");
                this.console.ResetColor();
                this.console.WriteLine($"{@event.Summary} ({when})");
                index++;
            }
        }


        private void SetColor(string calendarId)
        {
            this.console.ForegroundColor = calendarId switch {
                "bn1j5jeikkv53v8mg687fk1324@group.calendar.google.com" => ConsoleColor.Yellow,
                "t.w.brachthuizer@gmail.com" => ConsoleColor.Red,
                "9ssl6im7hpe1c97rebr4csgstg@group.calendar.google.com" => ConsoleColor.DarkGreen,
                "brachthuizer@gmail.com" => ConsoleColor.Green,
                _ => ConsoleColor.White,
            };
        }
    }
}