using Catharsium.Calendar.Core.Entities.Interfaces;
using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.UI.Console.ActionHandlers;

namespace Catharsium.Calendar.Core.Logic.Actions
{
    public class EventCreator : IEventCreator
    {
        private readonly IEventService eventService;


        public EventCreator(IEventService eventService)
        {
            this.eventService = eventService;
        }


        public Event Create(Event @event, string calendarId)
        {
            return this.eventService.CreateEvent(calendarId, @event);
        }
    }
}