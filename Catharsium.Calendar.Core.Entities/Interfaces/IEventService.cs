using System.Collections.Generic;
using Catharsium.Calendar.Core.Entities.Models;

namespace Catharsium.Calendar.Core.Entities.Interfaces
{
    public interface IEventService
    {
        IEnumerable<Event> GetEvents(string calendarId);
    }
}