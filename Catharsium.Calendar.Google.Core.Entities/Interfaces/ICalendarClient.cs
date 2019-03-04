using System;
using Google.Apis.Calendar.v3.Data;

namespace Catharsium.Calendar.Google.Core.Entities.Interfaces
{
    public interface ICalendarClient
    {
        CalendarList GetCalendars();

        Event CreateEvent(string calendarId, string summary, DateTime start, DateTime end);

        Events GetEvents(string calendarId);
    }
}