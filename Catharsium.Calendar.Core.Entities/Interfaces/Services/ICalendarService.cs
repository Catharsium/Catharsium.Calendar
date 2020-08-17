using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catharsium.Calendar.Core.Entities.Interfaces.Services
{
    public interface ICalendarService
    {
        Task<IEnumerable<Models.Calendar>> GetList();
        Task<Models.Calendar> Get(string calendarId);
    }
}