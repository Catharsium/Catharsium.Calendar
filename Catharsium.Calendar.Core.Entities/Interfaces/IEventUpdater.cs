using Catharsium.Calendar.Core.Entities.Models;

namespace Catharsium.Calendar.Core.Entities.Interfaces
{
    public interface IEventUpdater
    {
        Event Move(Event @event, string oldCalendarId, string newCalendarId);
    }
}