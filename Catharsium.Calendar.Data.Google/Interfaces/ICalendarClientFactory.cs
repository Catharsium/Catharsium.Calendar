using Google.Apis.Calendar.v3;

namespace Catharsium.Calendar.Data.Google.Interfaces
{
    public interface ICalendarClientFactory
    {
        string UserName { get; set; }

        string[] GetUserNames();

        CalendarService Get();
    }
}