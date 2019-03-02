using Google.Apis.Calendar.v3.Data;
using System;

namespace Catharsium.Calendar.Google.Entities.Interfaces
{
    public interface IGoogleCalendarClient
    {
        CalendarList GetCalendars();

        Event CreateEvent(string calendarId, string summary, DateTime start, DateTime end);

        Events GetEvents(string calendarId);
    }
}