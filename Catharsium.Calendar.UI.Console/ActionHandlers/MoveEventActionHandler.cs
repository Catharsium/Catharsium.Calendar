using System.Collections.Generic;
using System.Linq;
using Catharsium.Calendar.Core.Entities.Interfaces;
using Catharsium.Calendar.Core.Entities.Interfaces.Filters;
using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.Core.Logic.Interfaces;
using Catharsium.Calendar.UI.Console.Interfaces;
using Catharsium.Calendar.UI.Console.StepHandlers;

namespace Catharsium.Calendar.UI.Console.ActionHandlers
{
    public class MoveEventActionHandler : IMoveEventActionHandler
    {
        private readonly ICalendarStorage calendarStorage;
        private readonly ITextEventFilter textFilter;
        private readonly IEqualityComparer<Event> eventComparer;
        private readonly IChooseCalendarStepHandler chooseACalendarStepHandler;
        private readonly IChooseEventStepHandler chooseAnEventStepHandler;
        private readonly IEventUpdater eventUpdater;


        public MoveEventActionHandler(ICalendarStorage calendarStorage,
            ITextEventFilter textFilter,
            IEqualityComparer<Event> eventComparer,
            IChooseCalendarStepHandler chooseACalendarStepHandler,
            IChooseEventStepHandler chooseAnEventStepHandler,
            IEventUpdater eventUpdater)
        {
            this.calendarStorage = calendarStorage;
            this.textFilter = textFilter;
            this.eventComparer = eventComparer;
            this.chooseACalendarStepHandler = chooseACalendarStepHandler;
            this.chooseAnEventStepHandler = chooseAnEventStepHandler;
            this.eventUpdater = eventUpdater;
        }


        public void Run()
        {
            System.Console.WriteLine("Enter the query:");
            var query = System.Console.ReadLine();

            System.Console.WriteLine();
            System.Console.WriteLine("Matching events:");
            var events = this.calendarStorage.LoadAll().ToList();
            var filteredEvents = this.textFilter.ApplyToSummary(events, query).ToList();
            filteredEvents.AddRange(this.textFilter.ApplyToDescription(events, query));
            filteredEvents.AddRange(this.textFilter.ApplyToLocation(events, query));
            filteredEvents = filteredEvents
                .Distinct(this.eventComparer)
                .OrderBy(e => e.End.Value)
                .ToList();

            if (filteredEvents.Count > 0) {
                var @event = this.chooseAnEventStepHandler.Run(filteredEvents);
                if (@event == null) {
                    return;
                }

                var newCalendar = this.chooseACalendarStepHandler.ChooseACalendar();
                if (newCalendar != null) {
                    this.eventUpdater.Move(@event, @event.CalendarId, newCalendar.Id);
                }
            }
            else {
                System.Console.WriteLine($"No events found for query '{query}'.");
            }
        }
    }
}