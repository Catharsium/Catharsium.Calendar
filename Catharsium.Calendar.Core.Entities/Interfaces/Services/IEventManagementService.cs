using Catharsium.Calendar.Core.Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catharsium.Calendar.Core.Entities.Interfaces.Services
{
    public interface IEventManagementService
    {
        Task<IEnumerable<Event>> GetList(string calendarId, DateTime from, DateTime to);
        Task<Event> GetEvent(string calendarId, string eventId);
        Task<Event> CreateEvent(string calendarId, Event eventData);
        Task UpdateEvent(string calendarId, Event eventData);
        Task DeleteEvent(string calendarId, string eventId);
    }
}