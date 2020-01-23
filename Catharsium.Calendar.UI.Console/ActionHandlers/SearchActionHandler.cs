﻿using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.Core.Logic.Interfaces;
using Catharsium.Calendar.UI.Console.Interfaces;
using Catharsium.Util.Filters;
using Catharsium.Util.IO.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Catharsium.Calendar.UI.Console.ActionHandlers
{
    public class SearchActionHandler : ISearchActionHandler
    {
        private readonly IConsole console;
        private readonly ICalendarStorage calendarStorage;
        private readonly IEventFilterFactory eventFilterFactory;
        private readonly IEqualityComparer<Event> eventComparer;
        private readonly IShowEventsStepHandler showEventsStepHandler;


        public SearchActionHandler(
            IConsole console,
            ICalendarStorage calendarStorage,
            IEventFilterFactory eventFilterFactory,
            IEqualityComparer<Event> eventComparer,
            IShowEventsStepHandler showEventsStepHandler)
        {
            this.console = console;
            this.calendarStorage = calendarStorage;
            this.eventFilterFactory = eventFilterFactory;
            this.eventComparer = eventComparer;
            this.showEventsStepHandler = showEventsStepHandler;
        }


        public void Run()
        {
            var query = this.console.AskForText("Enter the query:");
            this.console.WriteLine();
            this.console.WriteLine("Matching events:");
            var events = this.calendarStorage.LoadAll().ToList();
            var descriptionFilter = this.eventFilterFactory.CreateDescriptionFilter(query);
            var locationFilter = this.eventFilterFactory.CreateLocationFilter(query);
            var summaryFilter = this.eventFilterFactory.CreateSummaryFilter(query);
            var orFilter = this.eventFilterFactory.CreateOrFilter(descriptionFilter, locationFilter, summaryFilter);
            var filteredEvents = events.ToList();//.Include(orFilter).ToList();
            filteredEvents = filteredEvents
                .Distinct(this.eventComparer)
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