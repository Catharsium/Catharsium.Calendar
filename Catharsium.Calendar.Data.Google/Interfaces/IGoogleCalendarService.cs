using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catharsium.Clients.GoogleCalendar.Interfaces;

public interface IGoogleCalendarService
{
    Task<IEnumerable<Models.Calendar>> GetList();
    Task<Models.Calendar> Get(string calendarId);
}