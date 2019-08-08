using Catharsium.Calendar.Core.Entities.Interfaces.Services;
using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.UI.Console.Interfaces;
using Catharsium.Util.IO.Interfaces;

namespace Catharsium.Calendar.UI.Console.ActionHandlers
{
    public class CreateEventActionHandler : ICreateEventActionHandler
    {
        private readonly IConsole console;
        private readonly IChooseCalendarStepHandler chooseCalendarStepHandler;
        private readonly IEventManagementService eventService;


        public CreateEventActionHandler(IConsole console, IChooseCalendarStepHandler chooseCalendarStepHandler, IEventManagementService eventService)
        {
            this.console = console;
            this.chooseCalendarStepHandler = chooseCalendarStepHandler;
            this.eventService = eventService;
        }


        public void Run()
        {
            var summary = this.console.AskForText("Enter the summary:");

            var startDate = this.console.AskForDate("Enter the start date (yyyy MM dd HH mm:");
            var endDate = this.console.AskForDate("Enter the end date (yyyy MM dd HH mm:");

            if (!startDate.HasValue || !endDate.HasValue) {
                return;
            }

            var newEvent = new Event {
                Summary = summary,
                Start = new Date {Value = startDate.Value},
                End = new Date {Value = endDate.Value}
            };

            var newCalendar = this.chooseCalendarStepHandler.Run();
            if (newCalendar != null) {
                this.eventService.CreateEvent(newCalendar.Id, newEvent);
            }
        }
    }
}