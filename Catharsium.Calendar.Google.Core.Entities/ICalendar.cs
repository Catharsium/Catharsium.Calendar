using System.Collections.Generic;
using Catharsium.Calendar.Google.Core.Entities.Models;

namespace Catharsium.Calendar.Google.Core.Entities
{
    public interface ICalendar
    {
        CalendarEvent CreateEvent();
        IEnumerable<CalendarEvent> GetEvents();
    }
}