using Catharsium.Calendar.Core.Entities.Interfaces.Services;
using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.Core.Entities.Models.Enums;
using Catharsium.Calendar.UI.Console.Interfaces;
using Catharsium.Util.IO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Catharsium.Calendar.UI.Console.StepHandlers
{
    public class ShowEventsStepHandler : IShowEventsStepHandler
    {
        private readonly IConsole console;
        private readonly ICalendarService calendarService;


        public ShowEventsStepHandler(IConsole console, ICalendarService calendarService)
        {
            this.console = console;
            this.calendarService = calendarService;
        }


        public void ShowEvents(IEnumerable<Event> events)
        {
            var index = 0;
            foreach (var @event in events) {
                var when = @event.Start.Value.ToString("yyyy MMMM dd");
                if (@event.Start.HasTime) {
                    when += @event.Start.Value.ToString(" (HH:mm - ") + @event.End.Value.ToString("HH:mm)");
                }

                var calendars = this.calendarService.GetList();
                var calendar = calendars.FirstOrDefault(c => c.Id == @event.CalendarId);
                var calendarName = calendar != null ? calendar.Summary : "";
                this.SetColor(@event.Category);
                this.console.Write($"[{index + 1}]");
                this.SetColor(@event.CalendarId);
                this.console.WriteLine($" ({calendarName})");
                this.console.ResetColor();
                this.console.WriteLine($"{@event.Summary} ({when})");
                index++;
            }
        }


        private void SetColor(Category category)
        {
            switch (category) {
                case Category.PersonalOption:
                    this.console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case Category.PersonalAppointment:
                    this.console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case Category.PersonalCommitment:
                    this.console.ForegroundColor = ConsoleColor.DarkBlue;
                    break;
                case Category.ProfessionalOption:
                    this.console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case Category.ProfessionalAppointment:
                    this.console.ForegroundColor = ConsoleColor.Red;
                    break;
                case Category.ProfessionalCommitment:
                    this.console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case Category.Traveling:
                    this.console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
                case Category.Free:
                    this.console.ForegroundColor = ConsoleColor.Green;
                    break;
                case Category.PartnerCommitment:
                    this.console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case Category.Birthday:
                    break;
                case Category.Meal:
                    break;
                case Category.Special:
                    break;
                case Category.Unknown:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }


        private void SetColor(string calendarId)
        {
            switch (calendarId) {
                case "bn1j5jeikkv53v8mg687fk1324@group.calendar.google.com":
                    this.console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "t.w.brachthuizer@gmail.com":
                    this.console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "9ssl6im7hpe1c97rebr4csgstg@group.calendar.google.com":
                    this.console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;
                case "brachthuizer@gmail.com":
                    this.console.ForegroundColor = ConsoleColor.Green;
                    break;
                default:
                    this.console.ForegroundColor = ConsoleColor.White;
                    break;
            }
        }
    }
}