using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.UI.Console.Interfaces;
using Catharsium.Util.IO.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Catharsium.Calendar.UI.Console.StepHandlers
{
    public class ChooseEventStepHandler : IChooseEventStepHandler
    {
        private readonly IConsole console;
        private readonly IShowEventsStepHandler showEventsStepHandler;


        public ChooseEventStepHandler(IConsole console, IShowEventsStepHandler showEventsStepHandler)
        {
            this.console = console;
            this.showEventsStepHandler = showEventsStepHandler;
        }


        public Event Run(IEnumerable<Event> events)
        {
            var eventsList = events.ToList();
            this.showEventsStepHandler.ShowEvents(eventsList);

            this.console.WriteLine("Choose an event:");
            var input = this.console.AskForInt();
            return input.HasValue ? eventsList[input.Value - 1] : null;
        }
    }
}