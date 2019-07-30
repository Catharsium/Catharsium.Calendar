using Catharsium.Calendar.Core.Entities.Models;

namespace Catharsium.Calendar.UI.Console.ActionHandlers
{
    public interface IEventCreator
    {
        Event Create(Event @event, string calendarId);
    }
}