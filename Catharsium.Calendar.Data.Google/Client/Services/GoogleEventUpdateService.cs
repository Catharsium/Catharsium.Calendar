﻿using Catharsium.Calendar.Core.Entities.Interfaces.Services;
using Catharsium.Calendar.Core.Entities.Models;
using System.Threading.Tasks;

namespace Catharsium.Calendar.Data.Google.Client.Services
{
    public class GoogleEventUpdateService : IEventUpdateService
    {
        private readonly IEventManagementService eventService;


        public GoogleEventUpdateService(IEventManagementService eventService)
        {
            this.eventService = eventService;
        }


        public async Task<Event> Move(Event @event, string oldCalendarId, string newCalendarId)
        {
            return await Task.Run(() => {
                this.eventService.DeleteEvent(oldCalendarId, @event.Id);
                return this.eventService.CreateEvent(newCalendarId, @event);
            });
        }
    }
}