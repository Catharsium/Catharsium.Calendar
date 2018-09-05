using Google.Apis.Calendar.v3;

namespace Catharsium.Calendar.Google
{
    public interface IGoogleCalendarServiceFactory
    {
        CalendarService CreateService();
    }
}