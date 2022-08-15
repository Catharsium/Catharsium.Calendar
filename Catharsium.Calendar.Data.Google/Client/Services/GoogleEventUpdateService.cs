using Catharsium.Clients.GoogleCalendar.Interfaces;
using Catharsium.Clients.GoogleCalendar.Models;
using System.Threading.Tasks;

namespace Catharsium.Clients.GoogleCalendar.Client.Services;

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