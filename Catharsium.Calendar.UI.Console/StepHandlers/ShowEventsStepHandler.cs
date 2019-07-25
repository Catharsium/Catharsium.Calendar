using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.Core.Entities.Models.Enums;
using Catharsium.Calendar.UI.Console.Interfaces;
using System;
using System.Collections.Generic;

namespace Catharsium.Calendar.UI.Console.StepHandlers
{
    public class ShowEventsStepHandler : IShowEventsStepHandler
    {
        public void ShowEvents(IEnumerable<Event> filteredEvents)
        {
            foreach (var eventItem in filteredEvents) {
                var when = eventItem.Start.Value.ToString("yyyy MMMM dd");
                if (eventItem.Start.HasTime) {
                    when += eventItem.Start.Value.ToString(" (HH:mm - ") + eventItem.End.Value.ToString("HH:mm)");
                }

                if (eventItem.Category == Category.PersonalOption) {
                    System.Console.ForegroundColor = ConsoleColor.Cyan;
                }

                if (eventItem.Category == Category.PersonalAppointment) {
                    System.Console.ForegroundColor = ConsoleColor.Blue;
                }

                if (eventItem.Category == Category.PersonalCommitment) {
                    System.Console.ForegroundColor = ConsoleColor.DarkBlue;
                }

                if (eventItem.Category == Category.ProfessionalOption) {
                    System.Console.ForegroundColor = ConsoleColor.DarkYellow;
                }

                if (eventItem.Category == Category.ProfessionalAppointment) {
                    System.Console.ForegroundColor = ConsoleColor.Red;
                }

                if (eventItem.Category == Category.ProfessionalCommitment) {
                    System.Console.ForegroundColor = ConsoleColor.DarkRed;
                }

                if (eventItem.Category == Category.Traveling) {
                    System.Console.ForegroundColor = ConsoleColor.DarkGray;
                }

                if (eventItem.Category == Category.Free) {
                    System.Console.ForegroundColor = ConsoleColor.Green;
                }

                if (eventItem.Category == Category.PartnerCommitment) {
                    System.Console.ForegroundColor = ConsoleColor.Magenta;
                }

                System.Console.WriteLine("{0} ({1})", eventItem.Summary, when);
                System.Console.ResetColor();
            }
        }
    }
}