using System;
using Catharsium.Calendar.Core.Logic.Interfaces;
using Catharsium.Calendar.UI.Console._Configuration;
using Catharsium.Calendar.UI.Console.Interfaces;
using Catharsium.Util.IO.Interfaces;

namespace Catharsium.Calendar.UI.Console.ActionHandlers
{
    public class ScheduleActionHandler : IScheduleActionHandler
    {
        private readonly IAppointmentScheduler appointmentScheduler;
        private readonly IConsole console;
        private readonly CalendarGoogleUiConfiguration configuration;


        public ScheduleActionHandler(IAppointmentScheduler appointmentScheduler, IConsole console, CalendarGoogleUiConfiguration configuration)
        {
            this.appointmentScheduler = appointmentScheduler;
            this.console = console;
            this.configuration = configuration;
        }


        public void Run()
        {
            var startDate = this.console.AskForDate("Enter the start date (yyyy MM dd");
            var endDate = this.console.AskForDate("Enter the end date (yyyy MM dd");

            if (!startDate.HasValue) {
                startDate = DateTime.Today;
                var delta = DayOfWeek.Monday - startDate.Value.DayOfWeek;
                var monday = startDate.Value.AddDays(delta + 7);
                startDate = monday;
            }

            if (!endDate.HasValue) {
                endDate = startDate.Value.AddDays(7);
            }

            this.appointmentScheduler.GenerateFor(startDate.Value, endDate.Value, this.configuration.SchedulerSettings);
        }
    }
}