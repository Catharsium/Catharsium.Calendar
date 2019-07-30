using Catharsium.Calendar.Core.Entities.Interfaces.Services;
using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.Core.Entities.Models.Enums;
using Catharsium.Calendar.UI.Console.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Catharsium.Calendar.UI.Console.StepHandlers
{
    public class ShowEventsStepHandler : IShowEventsStepHandler
    {
        private readonly ICalendarService calendarService;


        public ShowEventsStepHandler(ICalendarService calendarService)
        {
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
                SetColor(@event.Category);
                System.Console.Write($"[{index + 1}]");
                SetColor(@event.CalendarId);
                System.Console.WriteLine($" ({calendarName})");
                System.Console.ResetColor();
                System.Console.WriteLine($"{@event.Summary} ({when})");
                index++;
            }
        }


        private static void SetColor(Category category)
        {
            switch (category) {
                case Category.PersonalOption:
                    System.Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case Category.PersonalAppointment:
                    System.Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case Category.PersonalCommitment:
                    System.Console.ForegroundColor = ConsoleColor.DarkBlue;
                    break;
                case Category.ProfessionalOption:
                    System.Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case Category.ProfessionalAppointment:
                    System.Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case Category.ProfessionalCommitment:
                    System.Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case Category.Traveling:
                    System.Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
                case Category.Free:
                    System.Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case Category.PartnerCommitment:
                    System.Console.ForegroundColor = ConsoleColor.Magenta;
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


        private static void SetColor(string calendarId)
        {
            switch (calendarId) {
                case "bn1j5jeikkv53v8mg687fk1324@group.calendar.google.com":
                    System.Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "t.w.brachthuizer@gmail.com":
                    System.Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "9ssl6im7hpe1c97rebr4csgstg@group.calendar.google.com":
                    System.Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;
                case "brachthuizer@gmail.com":
                    System.Console.ForegroundColor = ConsoleColor.Green;
                    break;
                default:
                    System.Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
        }
    }
}