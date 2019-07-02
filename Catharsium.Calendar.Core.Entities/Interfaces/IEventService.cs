using Catharsium.Calendar.Core.Entities.Models;
using System.Collections.Generic;

namespace Catharsium.Calendar.Core.Entities.Interfaces
{
    public interface IEventService
    {
        IEnumerable<Event> GetList(string calendarId);
        Event GetEvent(string calendarId, string eventId);
        Event CreateEvent(string calendarId, Event eventData);
        void UpdateEvent(string calendarId, Event eventData);
        void DeleteEvent(string calendarId, string eventId);
    }
}