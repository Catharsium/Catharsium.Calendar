using System.IO;
using Catharsium.Calendar.Google.Core.Entities.Interfaces;
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

            var serviceProvider = new ServiceCollection()
                // .AddLogging(configure => configure.AddConsole())
                .AddGoogleCalendarConsoleUi(configuration)
                .BuildServiceProvider();

            var factory = serviceProvider.GetService<ICalendarClientFactory>();
            var client = serviceProvider.GetService<ICalendarClient>();

            System.Console.WriteLine("Available calendars:");
            var calendars = client.GetCalendars();
            for (var i = 0; i < calendars.Items.Count; i++)
            {
                System.Console.WriteLine($"[ {i + 1} ] {calendars.Items[i].Summary}");
            }
            System.Console.WriteLine("Enter the index of the calendar:");

            var requestedIndex = System.Console.ReadLine();
            if (int.TryParse(requestedIndex, out var calendarIndex))
            {                                
                System.Console.WriteLine();
                System.Console.WriteLine("Upcoming events:");
                var events = client.GetEvents(calendars.Items[calendarIndex - 1].Id);
                if (events.Items != null && events.Items.Count > 0)
                {
                    foreach (var eventItem in events.Items)
                    {
                        var when = eventItem.Start.DateTime.ToString();
                        if (string.IsNullOrEmpty(when))
                        {
                            when = eventItem.Start.Date;
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