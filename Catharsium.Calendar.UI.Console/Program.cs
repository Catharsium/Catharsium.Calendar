﻿using System.IO;
using System.Linq;
using AutoMapper;
using Catharsium.Calendar.Core.Entities.Interfaces;
using Catharsium.Calendar.Google.Configuration.AutoMapper;
using Catharsium.Calendar.Google.UI.Console.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catharsium.Calendar.Google.UI.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, false);
            var configuration = builder.Build();

            var serviceCollection = new ServiceCollection();

            var serviceProvider = serviceCollection
                // .AddLogging(configure => configure.AddConsole())
                .AddGoogleCalendarConsoleUi(configuration)
                .BuildServiceProvider();

            var calendarService = serviceProvider.GetService<ICalendarService>();
            var eventService = serviceProvider.GetService<IEventService>();

            System.Console.WriteLine("Available calendars:");
            var calendars = calendarService.GetCalendars().ToList();
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
                var events = eventService.GetEvents(calendars[calendarIndex - 1].Id).ToList();
                if (events != null && events.Count > 0)
                {
                    foreach (var eventItem in events)
                    {
                        var when = eventItem.Start.Value.ToString("yyyy MMMM dd");
                        if (eventItem.Start.HasTime)
                        {
                            when += eventItem.Start.Value.ToString(" (HH:mm)");
                        }
                            
                        System.Console.WriteLine("{0} ({1})", eventItem.Summary, when);
                    }
                }
                else
                {
                    System.Console.WriteLine("No upcoming events found.");
                }
            }

            System.Console.Read();
        }
    }
}