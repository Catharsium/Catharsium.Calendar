using Catharsium.Calendar.Core.Entities.Interfaces;
using Catharsium.Calendar.Core.Entities.Interfaces.Filters;
using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.Core.Logic.Interfaces;
using Catharsium.Calendar.UI.Console._Configuration;
using Catharsium.Calendar.UI.Console.Enums;
using Catharsium.Util.Enums;
using Catharsium.Util.Time.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Catharsium.Calendar.Core.Entities.Models.Enums;
using Catharsium.Calendar.Google.Client.Services;

namespace Catharsium.Calendar.UI.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, false);
            var configuration = builder.Build();

            var serviceProvider = new ServiceCollection()
                .AddLogging(configure => configure.AddConsole())
                .AddGoogleCalendarConsoleUi(configuration)
                .BuildServiceProvider();

            var calendarService = serviceProvider.GetService<ICalendarService>();
            var calendarStorage = serviceProvider.GetService<ICalendarStorage>();
            var textFilter = serviceProvider.GetService<ITextEventFilter>();
            var eventComparer = serviceProvider.GetService<IEqualityComparer<Event>>();
            var calendarImporter = serviceProvider.GetService<ICalendarImporter>();

            while (true) {
                System.Console.WriteLine("Choose an action:");

                var actions = Enum.GetValues(typeof(UserActions));
                foreach (int action in actions) {
                    System.Console.WriteLine($"[{action}] {Enum.GetName(typeof(UserActions), action)}");
                }

                var requestedIndex = System.Console.ReadLine();

                if (requestedIndex == null || requestedIndex.ToLower() == "q") {
                    break;
                }

                var requestedAction = requestedIndex.ParseEnum(UserActions.Quit);
                if (requestedAction == UserActions.Quit) {
                    break;
                }

                var calendars = calendarService.GetList().ToList();

                if (requestedAction == UserActions.Import) {
                    ImportAction(calendars, calendarImporter);
                }

                if (requestedAction == UserActions.Load) {
                    LoadAction(calendarStorage);
                }

                if (requestedAction == UserActions.Search) {
                    SearchAction(calendarStorage, textFilter, eventComparer);
                }
            }
        }


        private static void ImportAction(List<Core.Entities.Models.Calendar> calendars, ICalendarImporter calendarImporter)
        {
            var calendar = ChooseACalendar(calendars);
            if (calendar == null) {
                return;
            }

            calendarImporter.Import(calendar.Id, new DateTime(2001, 1, 1), DateTime.Now);
        }


        private static void LoadAction(ICalendarStorage calendarStorage)
        {
            var events = calendarStorage.LoadAll().ToList();
            var duration = CalculateTotalTime(events);
            System.Console.WriteLine($"{events.Count} events found for a total of {duration} duration.");
            System.Console.WriteLine();
        }


        private static void SearchAction(ICalendarStorage calendarStorage, ITextEventFilter textFilter, IEqualityComparer<Event> eventComparer)
        {
            System.Console.WriteLine("Enter the query:");
            var query = System.Console.ReadLine();

            System.Console.WriteLine();
            System.Console.WriteLine("Matching events:");
            var events = calendarStorage.LoadAll().ToList();
            var filteredEvents = textFilter.ApplyToSummary(events, query).ToList();
            filteredEvents.AddRange(textFilter.ApplyToDescription(events, query));
            filteredEvents.AddRange(textFilter.ApplyToLocation(events, query));
            filteredEvents = filteredEvents
                .Distinct(eventComparer)
                .OrderBy(e => e.End.Value)
                .ToList();
            var duration = CalculateTotalTime(filteredEvents);

            if (filteredEvents.Count > 0) {
                ShowEvents(filteredEvents);
                System.Console.WriteLine($"{filteredEvents.Count} events found for a total of {duration} duration.");
                System.Console.WriteLine();
            }
            else {
                System.Console.WriteLine($"No events found for query '{query}'.");
            }
        }


        private static Core.Entities.Models.Calendar ChooseACalendar(List<Core.Entities.Models.Calendar> calendars)
        {
            System.Console.WriteLine("Choose a calendar:");
            for (var i = 0; i < calendars.Count; i++) {
                System.Console.WriteLine($"[{i + 1}] {calendars[i].Summary}");
            }

            var requestedIndex = System.Console.ReadLine();
            if (int.TryParse(requestedIndex, out var calendarIndex)) {
                return calendars[calendarIndex - 1];
            }

            System.Console.WriteLine("No valid calendar chosen.");

            return null;
        }


        private static void ShowEvents(IEnumerable<Event> filteredEvents)
        {
            foreach (var eventItem in filteredEvents) {
                var when = eventItem.Start.Value.ToString("yyyy MMMM dd");
                if (eventItem.Start.HasTime) {
                    when += eventItem.Start.Value.ToString(" (HH:mm - ") + eventItem.End.Value.ToString("HH:mm)");
                }

                if (eventItem.Category == Category.PersonalOption)
                {
                    System.Console.ForegroundColor = ConsoleColor.Cyan;
                }
                if (eventItem.Category == Category.PersonalAppointment)
                {
                    System.Console.ForegroundColor = ConsoleColor.Blue;
                }
                if (eventItem.Category == Category.PersonalCommitment)
                {
                    System.Console.ForegroundColor = ConsoleColor.DarkBlue;
                }

                if (eventItem.Category == Category.ProfessionalOption)
                {
                    System.Console.ForegroundColor = ConsoleColor.DarkYellow;
                }
                if (eventItem.Category == Category.ProfessionalAppointment)
                {
                    System.Console.ForegroundColor = ConsoleColor.Red;
                }
                if (eventItem.Category == Category.ProfessionalCommitment) {
                    System.Console.ForegroundColor = ConsoleColor.DarkRed;
                }
                
                if (eventItem.Category == Category.Traveling)
                {
                    System.Console.ForegroundColor = ConsoleColor.DarkGray;
                }

                if (eventItem.Category == Category.Free)
                {
                    System.Console.ForegroundColor = ConsoleColor.Green;
                }

                if (eventItem.Category == Category.PartnerCommitment)
                {
                    System.Console.ForegroundColor = ConsoleColor.Magenta;
                }

                System.Console.WriteLine("{0} ({1})", eventItem.Summary, when);
                System.Console.ResetColor();
            }
        }


        private static string CalculateTotalTime(IEnumerable<Event> filteredEvents)
        {
            var time = filteredEvents.Sum(e => e.End.Value - e.Start.Value);
            var days = time.Days != 0 ? $"{time.Days} days, " : "";
            var hours = $"{time.Hours} hours";
            var minutes = time.Minutes != 0 ? $", {time.Minutes} minutes" : "";
            return $"{days}{hours}{minutes}";
        }
    }
}