using Catharsium.Calendar.UI.Console.Interfaces;
using Catharsium.Clients.GoogleCalendar.Interfaces;
using Catharsium.Clients.GoogleCalendar.Models;
using Catharsium.Util.IO.Console.ActionHandlers.Base;
using Catharsium.Util.IO.Console.Interfaces;
using System.Threading.Tasks;

namespace Catharsium.Calendar.UI.Console.ActionHandlers;

public class CreateEventActionHandler : BaseActionHandler
{
    private readonly IChooseCalendarStepHandler chooseCalendarStepHandler;
    private readonly IEventManagementService eventService;


    public string FriendlyName => "Create event";


    public CreateEventActionHandler(IChooseCalendarStepHandler chooseCalendarStepHandler, IEventManagementService eventService, IConsole console)
        : base(console, "Create event")
    {
        this.chooseCalendarStepHandler = chooseCalendarStepHandler;
        this.eventService = eventService;
    }


    public override async Task Run()
    {
        var summary = this.console.AskForText("Enter the summary:");
        var startDate = this.console.AskForDate("Enter the start date (yyyy MM dd HH mm:");
        var endDate = this.console.AskForDate("Enter the end date (yyyy MM dd HH mm:");

        if(!startDate.HasValue) {
            return;
        }

        if(!endDate.HasValue) {
            endDate = startDate.Value.AddMinutes(30);
        }

        var newEvent = new Event {
            Summary = summary,
            Start = new Date { Value = startDate.Value },
            End = new Date { Value = endDate.Value }
        };

        var newCalendar = await this.chooseCalendarStepHandler.Run();
        if(newCalendar != null) {
            await this.eventService.CreateEvent(newCalendar.Id, newEvent);
        }
    }
}