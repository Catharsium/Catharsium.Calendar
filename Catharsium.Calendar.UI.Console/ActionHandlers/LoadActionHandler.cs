using Catharsium.Clients.GoogleCalendar.Models;
using Catharsium.Util.IO.Console.ActionHandlers.Base;
using Catharsium.Util.IO.Console.Interfaces;
using Catharsium.Util.IO.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Catharsium.Calendar.UI.Console.ActionHandlers;

public class LoadActionHandler : BaseActionHandler
{
    private readonly IJsonFileRepository<Event> jsonFileRepository;


    public LoadActionHandler(IJsonFileRepository<Event> jsonFileRepository, IConsole console)
        : base(console, "Load action")
    {
        this.jsonFileRepository = jsonFileRepository;
    }


    public override async Task Run()
    {
        var events = (await this.jsonFileRepository.LoadAll()).ToList();
        var duration = TotalTimeCalculator.CalculateTotalTime(events);
        this.console.WriteLine($"{events.Count} events found for a total of {duration} duration.");
        this.console.WriteLine();
    }
}