using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.Core.Entities.Models.Scheduler;
using Catharsium.Calendar.Core.Logic.Interfaces;
using Catharsium.Util.IO.Console.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catharsium.Calendar.Core.Logic.Scheduler
{
    public class TemplateScheduler : ITemplateScheduler
    {
        private readonly IEnumerable<IAppointmentGenerator> appointmentGenerators;
        private readonly IConsole console;


        public TemplateScheduler(IEnumerable<IAppointmentGenerator> appointmentGenerators, IConsole console)
        {
            this.appointmentGenerators = appointmentGenerators;
            this.console = console;
        }


        public async Task<Event[]> Schedule(DateTime date, Template template)
        {
            var result = new List<Event>();
            var currentStartDate = date;
            var generator = this.appointmentGenerators.FirstOrDefault(g => g.Interval == Interval.Single);
            if (generator != null) {
                foreach (var appointment in template.Appointments) {
                    this.CompleteTemplate(appointment);
                    result.AddRange(await generator.GenerateFor(currentStartDate, currentStartDate = currentStartDate.AddMinutes(appointment.DurationInMinutes), appointment));
                }
            }

            return await Task.Run(() => result.ToArray());
        }


        private void CompleteTemplate(Appointment appointment)
        {
            if (appointment.DurationInMinutes <= 0) {
                var duration = this.console.AskForInt($"Specify the duration in minutes for '{appointment.Summary}'");
                appointment.DurationInMinutes = duration ?? 30;
            }
            if (appointment.Summary.Contains("?")) {
                var newSummary = this.console.AskForText($"Fill out '{appointment.Summary}'");
                if (!string.IsNullOrWhiteSpace(newSummary)) {
                    appointment.Summary = appointment.Summary.Replace("?", newSummary);
                }
            }
        }
    }
}