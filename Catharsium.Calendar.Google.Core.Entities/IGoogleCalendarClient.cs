using Google.Apis.Calendar.v3.Data;

namespace Catharsium.Calendar.Google
{
    public interface IGoogleCalendarClient
    {
        Event CreateEvent();

        Events GetEvents();
    }
}