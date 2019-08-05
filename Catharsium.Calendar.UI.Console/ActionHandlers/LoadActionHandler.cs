using Catharsium.Calendar.Core.Logic.Interfaces;
using Catharsium.Calendar.UI.Console.Interfaces;
using Catharsium.Util.IO.Interfaces;
using System.Linq;

namespace Catharsium.Calendar.UI.Console.ActionHandlers
{
    public class LoadActionHandler : ILoadActionHandler
    {
        private readonly IConsole console;
        private readonly ICalendarStorage calendarStorage;


        public LoadActionHandler(IConsole console, ICalendarStorage calendarStorage)
        {
            this.console = console;
            this.calendarStorage = calendarStorage;
        }


        public void Run()
        {
            var events = this.calendarStorage.LoadAll().ToList();
            var duration = TotalTimeCalculator.CalculateTotalTime(events);
            this.console.WriteLine($"{events.Count} events found for a total of {duration} duration.");
            this.console.WriteLine();
        }
    }
}