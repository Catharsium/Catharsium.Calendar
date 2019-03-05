using Google.Apis.Calendar.v3;

namespace Catharsium.Calendar.Core.Entities.Interfaces
{
    public interface ICalendarClientFactory
    {
        CalendarService CreateClient();
    }
}