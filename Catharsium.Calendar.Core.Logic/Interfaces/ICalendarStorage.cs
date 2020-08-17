using Catharsium.Calendar.Core.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catharsium.Calendar.Core.Logic.Interfaces
{
    public interface ICalendarStorage
    {
        Task<IEnumerable<Event>> LoadAll();
        Task<IEnumerable<Event>> Load(string fileName);
        Task Store(IEnumerable<Event> events, string fileName);
    }
}