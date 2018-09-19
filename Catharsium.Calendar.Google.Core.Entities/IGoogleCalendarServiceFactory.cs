using Google.Apis.Calendar.v3;

namespace Catharsium.Calendar.Google.Core.Entities
{
    public interface IGoogleCalendarServiceFactory
    {
        CalendarService CreateService();
    }
}