using Catharsium.Calendar.Core.Entities.Models;
using System;
using System.Collections.Generic;

namespace Catharsium.Calendar.Core.Entities.Interfaces.Services
{
    public interface IEventManagementService
    {
        IEnumerable<Event> GetList(string calendarId, DateTime from, DateTime to);
        Event GetEvent(string calendarId, string eventId);
        Event CreateEvent(string calendarId, Event eventData);
        void UpdateEvent(string calendarId, Event eventData);
        void DeleteEvent(string calendarId, string eventId);
    }
}