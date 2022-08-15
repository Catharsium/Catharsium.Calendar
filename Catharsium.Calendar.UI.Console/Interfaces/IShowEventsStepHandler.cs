using Catharsium.External.GoogleCalendar.Client.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catharsium.Calendar.UI.Console.Interfaces;

public interface IShowEventsStepHandler
{
    Task ShowEvents(IEnumerable<Event> events);
}