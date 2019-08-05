using Google.Apis.Calendar.v3;

namespace Catharsium.Calendar.Google.Interfaces
{
    public interface ICalendarClientFactory
    {
        string UserName { get; set; }

        string[] GetUserNames();

        CalendarService Get();
    }
}