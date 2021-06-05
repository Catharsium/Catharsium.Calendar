using Catharsium.Calendar.Core.Entities.Interfaces.Services;
using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.Core.Entities.Models.Scheduler;
using Catharsium.Calendar.Core.Logic.Interfaces;
using Catharsium.Util.IO.Console.Interfaces;
using System;
using System.Threading.Tasks;

namespace Catharsium.Calendar.Core.Logic.Scheduler
{
    public class SingleAppointmentGenerator : IAppointmentGenerator
    {
        private readonly IEventManagementService eventManagementService;
        private readonly IConsole console;

        public Interval Interval => Interval.Single;


        public SingleAppointmentGenerator(IEventManagementService eventManagementService, IConsole console)
        {
            this.eventManagementService = eventManagementService;
            this.console = console;
        }


        public async Task<Event[]> GenerateFor(DateTime fromDate, DateTime toDate, Appointment appointment)
        {
            if (appointment.Summary.Contains("?")) {
                var newSummary = this.console.AskForText($"Please fill out '{appointment.Summary}'");
                if (!string.IsNullOrWhiteSpace(newSummary)) {
                    appointment.Summary = appointment.Summary.Replace("?", newSummary);
                }
            }
            return new[] {await this.eventManagementService.CreateEvent(
                appointment.CalendarId,
                new Event {
                    Summary = appointment.Summary,
                    Location = appointment.Location,
                    Start = new Date { Value = fromDate, HasTime = true },
                    End = new Date { Value = toDate, HasTime = true }
                }
            )};
        }
    }
}