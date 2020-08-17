using Catharsium.Calendar.Core.Logic.Interfaces;
using Catharsium.Util.IO.Console.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Catharsium.Calendar.UI.Console.ActionHandlers
{
    public class LoadActionHandler : IActionHandler
    {
        private readonly IConsole console;
        private readonly ICalendarStorage calendarStorage;


        public string FriendlyName => "Load action";


        public LoadActionHandler(IConsole console, ICalendarStorage calendarStorage)
        {
            this.console = console;
            this.calendarStorage = calendarStorage;
        }


        public async Task Run()
        {
            var events = (await this.calendarStorage.LoadAll()).ToList();
            var duration = TotalTimeCalculator.CalculateTotalTime(events);
            this.console.WriteLine($"{events.Count} events found for a total of {duration} duration.");
            this.console.WriteLine();
        }
    }
}