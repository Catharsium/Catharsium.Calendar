using Catharsium.Calendar.Core.Logic.Interfaces;
using Catharsium.Calendar.UI.Console.Interfaces;
using System.Linq;

namespace Catharsium.Calendar.UI.Console.ActionHandlers
{
    public class LoadActionHandler : ILoadActionHandler
    {
        private readonly ICalendarStorage calendarStorage;


        public LoadActionHandler(ICalendarStorage calendarStorage)
        {
            this.calendarStorage = calendarStorage;
        }


        public void Run()
        {
            var events = this.calendarStorage.LoadAll().ToList();
            var duration = TotalTimeCalculator.CalculateTotalTime(events);
            System.Console.WriteLine($"{events.Count} events found for a total of {duration} duration.");
            System.Console.WriteLine();
        }
    }
}