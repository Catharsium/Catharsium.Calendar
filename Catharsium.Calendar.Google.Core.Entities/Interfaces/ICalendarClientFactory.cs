using Google.Apis.Calendar.v3;

namespace Catharsium.Calendar.Google.Core.Entities.Interfaces
{
    public interface ICalendarClientFactory
    {
        CalendarService CreateClient();
    }
}