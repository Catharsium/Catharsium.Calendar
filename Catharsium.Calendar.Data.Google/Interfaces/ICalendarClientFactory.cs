using Google.Apis.Calendar.v3;

namespace Catharsium.Clients.GoogleCalendar.Interfaces;

public interface ICalendarClientFactory
{
    string UserName { get; set; }

    string[] GetUserNames();

    CalendarService Get();
}