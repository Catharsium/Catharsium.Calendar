using Catharsium.Calendar.Core.Entities.Interfaces.Services;
using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.Core.Logic.Interfaces;
using Catharsium.Calendar.UI.Console.Interfaces;
using Catharsium.Util.Filters;
using Catharsium.Util.IO.Console.ActionHandlers.Base;
using Catharsium.Util.IO.Console.Interfaces;
using Catharsium.Util.IO.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Catharsium.Calendar.UI.Console.ActionHandlers;

public class MoveEventActionHandler : BaseActionHandler
{
    private readonly IJsonFileRepository<Event> jsonFileRepository;
    private readonly IEventFilterFactory eventFilterFactory;
    private readonly IEqualityComparer<Event> eventComparer;
    private readonly IChooseCalendarStepHandler chooseACalendarStepHandler;
    private readonly IChooseEventStepHandler chooseAnEventStepHandler;
    private readonly IEventUpdateService eventUpdater;


    public MoveEventActionHandler(
        IConsole console,
        IJsonFileRepository<Event> jsonFileRepository,
        IEventFilterFactory eventFilterFactory,
        IEqualityComparer<Event> eventComparer,
        IChooseCalendarStepHandler chooseACalendarStepHandler,
        IChooseEventStepHandler chooseAnEventStepHandler,
        IEventUpdateService eventUpdater)
        : base(console, "Move event")
    {
        this.jsonFileRepository = jsonFileRepository;
        this.eventFilterFactory = eventFilterFactory;
        this.eventComparer = eventComparer;
        this.chooseACalendarStepHandler = chooseACalendarStepHandler;
        this.chooseAnEventStepHandler = chooseAnEventStepHandler;
        this.eventUpdater = eventUpdater;
    }


    public override async Task Run()
    {
        var query = this.console.AskForText("Enter the query:");
        this.console.WriteLine();
        this.console.WriteLine("Matching events:");
        var events = (await this.jsonFileRepository.LoadAll()).ToList();
        var summaryFilter = this.eventFilterFactory.CreateSummaryFilter(query);
        var locationFilter = this.eventFilterFactory.CreateLocationFilter(query);
        var descriptionFilter = this.eventFilterFactory.CreateDescriptionFilter(query);
        var orFilter = this.eventFilterFactory.CreateOrFilter(summaryFilter, locationFilter, descriptionFilter);
        var filteredEvents = events.Include(orFilter).ToList();
        filteredEvents = filteredEvents
            .Distinct(this.eventComparer)
            .OrderBy(e => e.End.Value)
            .ToList();

        if (filteredEvents.Count > 0) {
            var @event = this.chooseAnEventStepHandler.Run(filteredEvents);
            if (@event == null) {
                return;
            }

            var newCalendar = await this.chooseACalendarStepHandler.Run();
            if (newCalendar != null) {
                await this.eventUpdater.Move(@event, @event.CalendarId, newCalendar.Id);
            }
        }
        else {
            this.console.WriteLine($"No events found for query '{query}'.");
        }
    }
}