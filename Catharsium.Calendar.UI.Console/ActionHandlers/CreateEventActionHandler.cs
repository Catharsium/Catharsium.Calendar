using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.UI.Console.Interfaces;
using System;
using System.Globalization;

namespace Catharsium.Calendar.UI.Console.ActionHandlers
{
    public class CreateEventActionHandler : ICreateEventActionHandler
    {
        private readonly IChooseCalendarStepHandler chooseCalendarStepHandler;
        private readonly IEventCreator eventCreator;


        public CreateEventActionHandler(IChooseCalendarStepHandler chooseCalendarStepHandler, IEventCreator eventCreator)
        {
            this.chooseCalendarStepHandler = chooseCalendarStepHandler;
            this.eventCreator = eventCreator;
        }


        public void Run()
        {
            System.Console.WriteLine("Enter the summary:");
            var summary = System.Console.ReadLine();

            System.Console.WriteLine("Enter the start date (yyyy MM dd:");
            var startDateInput = System.Console.ReadLine();
            System.Console.WriteLine("Enter the start time (HH mm:");
            var startTimeInput = System.Console.ReadLine();
            startTimeInput = startTimeInput.Replace("-", "").Replace(" ", "");
            startDateInput = startDateInput.Replace("-", "").Replace(" ", "") + startTimeInput;
            var startDate = DateTime.ParseExact(startDateInput, "yyyyMMddHHmm", CultureInfo.CurrentCulture);

            System.Console.WriteLine("Enter the end date (yyyy MM dd:");
            var endDateInput = System.Console.ReadLine();
            System.Console.WriteLine("Enter the end time (HH mm:");
            var endTimeInput = System.Console.ReadLine();
            endTimeInput = endTimeInput.Replace("-", "").Replace(" ", "");
            endDateInput = endDateInput.Replace("-", "").Replace(" ", "") + endTimeInput;
            var endDate = DateTime.ParseExact(endDateInput, "yyyyMMddHHmm", CultureInfo.CurrentCulture);

            var newEvent = new Event {
                Summary = summary,
                Start = new Date { Value = startDate },
                End = new Date { Value = endDate }
            };

            var newCalendar = this.chooseCalendarStepHandler.ChooseACalendar();
            if (newEvent != null && newCalendar != null) {
                this.eventCreator.Create(newEvent, newCalendar.Id);
            }
        }
    }
}