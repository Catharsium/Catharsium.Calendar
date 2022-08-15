using Catharsium.Calendar.UI.Console.Interfaces;
using Catharsium.Clients.GoogleCalendar.Interfaces;
using Catharsium.Util.IO.Console.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Catharsium.Calendar.UI.Console.StepHandlers
{
    public class ChooseCalendarStepHandler : IChooseCalendarStepHandler
    {
        private readonly IConsole console;
        private readonly IGoogleCalendarService calendarService;


        public ChooseCalendarStepHandler(IConsole console, IGoogleCalendarService calendarService)
        {
            this.console = console;
            this.calendarService = calendarService;
        }


        public async Task<Clients.GoogleCalendar.Models.Calendar> Run()
        {
            var calendars = (await this.calendarService.GetList()).ToList();
            this.console.WriteLine("Choose a calendar:");
            for (var i = 0; i < calendars.Count; i++) {
                this.console.WriteLine($"[{i + 1}] {calendars[i].Summary}");
            }

            var calendarIndex = this.console.AskForInt();
            if (calendarIndex.HasValue) {
                return await Task.FromResult(calendars[calendarIndex.Value - 1]);
            }

            this.console.WriteLine("No valid calendar chosen.");

            return await Task.FromResult(null as Clients.GoogleCalendar.Models.Calendar);
        }
    }
}