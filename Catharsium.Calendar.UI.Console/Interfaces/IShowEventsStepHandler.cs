using Catharsium.Calendar.Core.Entities.Models;
using System.Collections.Generic;

namespace Catharsium.Calendar.UI.Console.Interfaces
{
    public interface IShowEventsStepHandler
    {
        void ShowEvents(IEnumerable<Event> events);
    }
}