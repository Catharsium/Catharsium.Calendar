using Catharsium.Calendar.Core.Logic.Interfaces;
using Catharsium.Calendar.UI.Console.Interfaces;
using Catharsium.Clients.GoogleCalendar.Models;
using Catharsium.Util.Filters;
using Catharsium.Util.IO.Console.ActionHandlers.Base;
using Catharsium.Util.IO.Console.Interfaces;
using Catharsium.Util.IO.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catharsium.Calendar.UI.Console.ActionHandlers;

public class SearchActionHandler : BaseActionHandler
{
    private readonly IJsonFileRepository<Event> jsonFileRepository;
    private readonly IEventFilterFactory eventFilterFactory;
    private readonly IEqualityComparer<Event> eventComparer;
    private readonly IShowEventsStepHandler showEventsStepHandler;


    public string FriendlyName => "Search";


    public SearchActionHandler(
        IConsole console,
        IJsonFileRepository<Event> jsonFileRepository,
        IEventFilterFactory eventFilterFactory,
        IEqualityComparer<Event> eventComparer,
        IShowEventsStepHandler showEventsStepHandler)
        : base(console, "Search")
    {
        this.jsonFileRepository = jsonFileRepository;
        this.eventFilterFactory = eventFilterFactory;
        this.eventComparer = eventComparer;
        this.showEventsStepHandler = showEventsStepHandler;
    }


    public override async Task Run()
    {
        var query = this.console.AskForText("Enter the query:");
        this.console.WriteLine();
        this.console.WriteLine("Matching events:");
        var events = (await this.jsonFileRepository.LoadAll()).ToList();
        var descriptionFilter = this.eventFilterFactory.CreateDescriptionFilter(query);
        var locationFilter = this.eventFilterFactory.CreateLocationFilter(query);
        var summaryFilter = this.eventFilterFactory.CreateSummaryFilter(query);
        var orFilter = this.eventFilterFactory.CreateOrFilter(descriptionFilter, locationFilter, summaryFilter);
        var filteredEvents = events.Include(orFilter).ToList();
        filteredEvents = filteredEvents
            .Distinct(this.eventComparer)
            .OrderBy(e => e.End.Value)
            .ToList();
        var duration = TotalTimeCalculator.CalculateTotalTime(filteredEvents);

        if(filteredEvents.Count > 0) {
            await this.showEventsStepHandler.ShowEvents(filteredEvents);
            this.console.WriteLine($"{filteredEvents.Count} events found for a total of {duration} duration.");
            this.console.WriteLine();
        }
        else {
            this.console.WriteLine($"No events found for query '{query}'.");
        }
    }
}