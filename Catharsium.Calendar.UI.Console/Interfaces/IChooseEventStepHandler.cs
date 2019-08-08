using System.Collections.Generic;
using Catharsium.Calendar.Core.Entities.Models;

namespace Catharsium.Calendar.UI.Console.Interfaces
{
    public interface IChooseEventStepHandler
    {
        Event Run(IEnumerable<Event> events);
    }
}