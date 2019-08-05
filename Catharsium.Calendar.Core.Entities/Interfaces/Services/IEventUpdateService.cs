using Catharsium.Calendar.Core.Entities.Models;

namespace Catharsium.Calendar.Core.Entities.Interfaces.Services
{
    public interface IEventUpdateService
    {
        Event Move(Event @event, string oldCalendarId, string newCalendarId);
    }
}