using Catharsium.Calendar.Core.Entities.Interfaces.Services;
using Catharsium.Calendar.Core.Entities.Models;

namespace Catharsium.Calendar.Google.Client.Services
{
    public class GoogleEventUpdateService : IEventUpdateService
    {
        private readonly IEventManagementService eventService;


        public GoogleEventUpdateService(IEventManagementService eventService)
        {
            this.eventService = eventService;
        }


        public Event Move(Event @event, string oldCalendarId, string newCalendarId)
        {
            this.eventService.DeleteEvent(oldCalendarId, @event.Id);
            var newEvent = this.eventService.CreateEvent(newCalendarId, @event);
            return newEvent ?? null;
        }
    }
}