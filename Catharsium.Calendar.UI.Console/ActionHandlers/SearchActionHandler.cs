using Catharsium.Calendar.Core.Entities.Interfaces.Filters;
using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.Core.Logic.Interfaces;
using Catharsium.Calendar.UI.Console.Interfaces;
using Catharsium.Util.IO.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Catharsium.Calendar.UI.Console.ActionHandlers
{
    public class SearchActionHandler : ISearchActionHandler
    {
        private readonly IConsole console;
        private readonly ICalendarStorage calendarStorage;
        private readonly ITextEventFilter textFilter;
        private readonly IEqualityComparer<Event> eventComparer;
        private readonly IShowEventsStepHandler showEventsStepHandler;


        public SearchActionHandler(
            IConsole console,
            ICalendarStorage calendarStorage,
            ITextEventFilter textFilter,
            IEqualityComparer<Event> eventComparer,
            IShowEventsStepHandler showEventsStepHandler)
        {
            this.console = console;
            this.calendarStorage = calendarStorage;
            this.textFilter = textFilter;
            this.eventComparer = eventComparer;
            this.showEventsStepHandler = showEventsStepHandler;
        }


        public void Run()
        {
            var query = this.console.AskForText("Enter the query:");
            this.console.WriteLine();
            this.console.WriteLine("Matching events:");
            var events = this.calendarStorage.LoadAll().ToList();
            var filteredEvents = this.textFilter.ApplyToSummary(events, query).ToList();
            filteredEvents.AddRange(this.textFilter.ApplyToDescription(events, query));
            filteredEvents.AddRange(this.textFilter.ApplyToLocation(events, query));
            filteredEvents = filteredEvents
                .Distinct(eventComparer)
                .OrderBy(e => e.End.Value)
                .ToList();
            var duration = TotalTimeCalculator.CalculateTotalTime(filteredEvents);

            if (filteredEvents.Count > 0) {
                this.showEventsStepHandler.ShowEvents(filteredEvents);
                this.console.WriteLine($"{filteredEvents.Count} events found for a total of {duration} duration.");
                this.console.WriteLine();
            }
            else {
                this.console.WriteLine($"No events found for query '{query}'.");
            }
        }
    }
}