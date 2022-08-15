using Catharsium.Clients.GoogleCalendar.Models;
using System.Collections.Generic;

namespace Catharsium.Calendar.UI.Console.Interfaces
{
    public interface IChooseEventStepHandler
    {
        Event Run(IEnumerable<Event> events);
    }
}