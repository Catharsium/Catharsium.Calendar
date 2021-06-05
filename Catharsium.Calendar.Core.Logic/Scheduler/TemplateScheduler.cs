using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.Core.Entities.Models.Scheduler;
using Catharsium.Calendar.Core.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catharsium.Calendar.Core.Logic.Scheduler
{
    public class TemplateScheduler : ITemplateScheduler
    {
        private readonly IEnumerable<IAppointmentGenerator> appointmentGenerators;


        public TemplateScheduler(IEnumerable<IAppointmentGenerator> appointmentGenerators)
        {
            this.appointmentGenerators = appointmentGenerators;
        }


        public async Task<Event[]> Schedule(DateTime date, Template template)
        {
            var result = new List<Event>();
            var currentStartDate = date;
            var generator = this.appointmentGenerators.FirstOrDefault(g => g.Interval == Interval.Single);
            if (generator != null) {
                foreach (var appointment in template.Appointments) {
                    result.AddRange(await generator.GenerateFor(currentStartDate, currentStartDate = currentStartDate.AddMinutes(appointment.DurationInMinutes), appointment));
                }
            }

            return await Task.Run(() => result.ToArray());
        }
    }
}