using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.UI.Console.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Catharsium.Calendar.UI.Console.StepHandlers
{
    public class ChooseEventStepHandler : IChooseEventStepHandler
    {
        private readonly IShowEventsStepHandler showEventsStepHandler;


        public ChooseEventStepHandler(IShowEventsStepHandler showEventsStepHandler)
        {
            this.showEventsStepHandler = showEventsStepHandler;
        }


        public Event Run(IEnumerable<Event> events)
        {
            var eventsList = events.ToList();
            this.showEventsStepHandler.ShowEvents(eventsList);

            System.Console.WriteLine("Choose an event:");
            var input = System.Console.ReadLine();
            return int.TryParse(input, out var index) ? eventsList[index] : null;
        }
    }
}