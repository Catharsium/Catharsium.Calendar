using Catharsium.External.GoogleCalendar.Client.Models;
using System.Collections.Generic;

namespace Catharsium.Calendar.UI.Console.Interfaces;

public interface IChooseEventStepHandler
{
    Event Run(IEnumerable<Event> events);
}