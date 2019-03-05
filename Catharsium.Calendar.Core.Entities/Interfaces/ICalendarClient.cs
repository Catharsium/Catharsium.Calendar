using System;
using Google.Apis.Calendar.v3.Data;

namespace Catharsium.Calendar.Core.Entities.Interfaces
{
    public interface ICalendarClient
    {
        Event CreateEvent(string calendarId, string summary, DateTime start, DateTime end);
    }
}