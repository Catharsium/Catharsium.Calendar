using System.Collections.Generic;

namespace Catharsium.Calendar.Core.Entities.Interfaces.Services
{
    public interface ICalendarService
    {
        IEnumerable<Models.Calendar> GetList();
        Models.Calendar Get(string calendarId);
    }
}