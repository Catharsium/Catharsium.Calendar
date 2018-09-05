using Catharsium.Calendar.Google;
using System;

namespace CalendarQuickstart
{
    public class Program
    {
        static void Main(string[] args)
        {
            var client = new GoogleCalendarClient(new GoogleCalendarServiceFactory());
            client.CreateEvent();
            var events = client.GetEvents();

            Console.WriteLine("Upcoming events:");
            if (events.Items != null && events.Items.Count > 0)
            {
                foreach (var eventItem in events.Items)
                {
                    var when = eventItem.Start.DateTime.ToString();
                    if (string.IsNullOrEmpty(when))
                    {
                        when = eventItem.Start.Date;
                    }
                    Console.WriteLine("{0} ({1})", eventItem.Summary, when);
                }
            }
            else
            {
                Console.WriteLine("No upcoming events found.");
            }
            Console.Read();
        }
    }
}