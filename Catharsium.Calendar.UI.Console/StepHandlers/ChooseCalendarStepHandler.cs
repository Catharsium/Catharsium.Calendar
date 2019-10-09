using Catharsium.Calendar.Core.Entities.Interfaces.Services;
using Catharsium.Calendar.UI.Console.Interfaces;
using Catharsium.Util.IO.Interfaces;
using System.Linq;

namespace Catharsium.Calendar.UI.Console.StepHandlers
{
    public class ChooseCalendarStepHandler : IChooseCalendarStepHandler
    {
        private readonly IConsole console;
        private readonly ICalendarService calendarService;


        public ChooseCalendarStepHandler(IConsole console, ICalendarService calendarService)
        { 
            this.console = console;
            this.calendarService = calendarService;
        }


        public Core.Entities.Models.Calendar Run()
        {
            var calendars = this.calendarService.GetList().ToList();
            this.console.WriteLine("Choose a calendar:");
            for (var i = 0; i < calendars.Count; i++) {
                this.console.WriteLine($"[{i + 1}] {calendars[i].Summary}");
            }

            var calendarIndex = this.console.AskForInt();
            if (calendarIndex.HasValue) {
                return calendars[calendarIndex.Value - 1];
            }

            this.console.WriteLine("No valid calendar chosen.");

            return null;
        }
    }
}