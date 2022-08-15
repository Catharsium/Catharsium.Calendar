using Catharsium.Clients.GoogleCalendar.Models;
using System.Threading.Tasks;

namespace Catharsium.Clients.GoogleCalendar.Interfaces;

public interface IEventUpdateService
{
    Task<Event> Move(Event @event, string oldCalendarId, string newCalendarId);
}