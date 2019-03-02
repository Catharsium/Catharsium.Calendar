using Google.Apis.Calendar.v3;

namespace Catharsium.Calendar.Google.Interfaces
{
    public interface IGoogleCalendarServiceFactory
    {
        CalendarService CreateService();
    }
}