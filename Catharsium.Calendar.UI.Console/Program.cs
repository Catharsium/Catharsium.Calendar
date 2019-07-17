using Catharsium.Calendar.Core.Entities.Interfaces;
using Catharsium.Calendar.Core.Logic.Interfaces;
using Catharsium.Calendar.UI.Console._Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;

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
            var eventService = serviceProvider.GetService<IEventService>();
            var eventRepository = serviceProvider.GetService<IEventRepository>();

            //var exporter = serviceProvider.GetService<ICalendarExporter>();
            //exporter.Export();

            System.Console.WriteLine("Available calendars:");
            var calendars = calendarService.GetList().ToList();
            for (var i = 0; i < calendars.Count; i++)
            {
                System.Console.WriteLine($"[ {i + 1} ] {calendars[i].Summary}");
            }
            System.Console.WriteLine("Enter the index of the calendar:");

            var requestedIndex = System.Console.ReadLine();

            if (int.TryParse(requestedIndex, out var calendarIndex))
            {
                System.Console.WriteLine();
                System.Console.WriteLine("Upcoming events:");
                var events = eventService.GetList(calendars[calendarIndex - 1].Id, new DateTime(2017, 1, 1), new DateTime(2017, 2, 1)).ToList();

                var time = events.Sum(e => (e.End.Value - e.Start.Value).TotalMinutes);

                if (events.Count > 0)
                {
                    foreach (var eventItem in events)
                    {
                        var when = eventItem.Start.Value.ToString("yyyy MMMM dd");
                        if (eventItem.Start.HasTime)
                        {
                            when += eventItem.Start.Value.ToString(" (HH:mm - ") + eventItem.End.Value.ToString("HH:mm)");
                        }

                        System.Console.WriteLine("{0} ({1})", eventItem.Summary, when);
                    }
                }
                else
                {
                    System.Console.WriteLine("No upcoming events found.");
                }
            }

            var x = eventRepository.Load("test");
        }
    }
}