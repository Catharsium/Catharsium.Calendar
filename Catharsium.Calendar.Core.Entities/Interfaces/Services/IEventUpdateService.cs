using Catharsium.Calendar.Core.Entities.Models;
using System.Threading.Tasks;

namespace Catharsium.Calendar.Core.Entities.Interfaces.Services
{
    public interface IEventUpdateService
    {
        Task<Event> Move(Event @event, string oldCalendarId, string newCalendarId);
    }
}