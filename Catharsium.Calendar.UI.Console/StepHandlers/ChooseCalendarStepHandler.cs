using Catharsium.Calendar.Core.Entities.Interfaces.Services;
using Catharsium.Calendar.UI.Console.Interfaces;
using System.Linq;

namespace Catharsium.Calendar.UI.Console.StepHandlers
{
    public class ChooseCalendarStepHandler : IChooseCalendarStepHandler
    {
        private readonly ICalendarService calendarService;


        public ChooseCalendarStepHandler(ICalendarService calendarService)
        {
            this.calendarService = calendarService;
        }


        public Core.Entities.Models.Calendar ChooseACalendar()
        {
            var calendars = this.calendarService.GetList().ToList();
            System.Console.WriteLine("Choose a calendar:");
            for (var i = 0; i < calendars.Count; i++) {
                System.Console.WriteLine($"[{i + 1}] {calendars[i].Summary}");
            }

            var requestedIndex = System.Console.ReadLine();
            if (int.TryParse(requestedIndex, out var calendarIndex)) {
                return calendars[calendarIndex - 1];
            }

            System.Console.WriteLine("No valid calendar chosen.");

            return null;
        }
    }
}