using Catharsium.Calendar.Core.Entities.Interfaces;
using Catharsium.Calendar.Core.Entities.Models;

namespace Catharsium.Calendar.Core.Logic.Actions
{
    public class EventUpdater : IEventUpdater
    {
        private readonly IEventService eventService;


        public EventUpdater(IEventService eventService)
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