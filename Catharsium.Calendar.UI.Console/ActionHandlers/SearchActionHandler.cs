using Catharsium.Calendar.Core.Entities.Interfaces.Filters;
using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.Core.Logic.Interfaces;
using Catharsium.Calendar.UI.Console.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Catharsium.Calendar.UI.Console.ActionHandlers
{
    public class SearchActionHandler : ISearchActionHandler
    {
        private readonly ICalendarStorage calendarStorage;
        private readonly ITextEventFilter textFilter;
        private readonly IEqualityComparer<Event> eventComparer;
        private readonly IShowEventsStepHandler showEventsStepHandler;


        public SearchActionHandler(ICalendarStorage calendarStorage,
            ITextEventFilter textFilter,
            IEqualityComparer<Event> eventComparer,
            IShowEventsStepHandler showEventsStepHandler)
        {
            this.calendarStorage = calendarStorage;
            this.textFilter = textFilter;
            this.eventComparer = eventComparer;
            this.showEventsStepHandler = showEventsStepHandler;
        }


        public void Run()
        {
            System.Console.WriteLine("Enter the query:");
            var query = System.Console.ReadLine();

            System.Console.WriteLine();
            System.Console.WriteLine("Matching events:");
            var events = calendarStorage.LoadAll().ToList();
            var filteredEvents = textFilter.ApplyToSummary(events, query).ToList();
            filteredEvents.AddRange(textFilter.ApplyToDescription(events, query));
            filteredEvents.AddRange(textFilter.ApplyToLocation(events, query));
            filteredEvents = filteredEvents
                .Distinct(eventComparer)
                .OrderBy(e => e.End.Value)
                .ToList();
            var duration = TotalTimeCalculator.CalculateTotalTime(filteredEvents);

            if (filteredEvents.Count > 0) {
                this.showEventsStepHandler.ShowEvents(filteredEvents);
                System.Console.WriteLine($"{filteredEvents.Count} events found for a total of {duration} duration.");
                System.Console.WriteLine();
            }
            else {
                System.Console.WriteLine($"No events found for query '{query}'.");
            }
        }
    }
}