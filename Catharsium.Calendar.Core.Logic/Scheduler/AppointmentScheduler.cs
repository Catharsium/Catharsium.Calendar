using Catharsium.Calendar.Core.Entities.Models.Scheduler;
using Catharsium.Calendar.Core.Logic.Interfaces;
using Catharsium.Clients.GoogleCalendar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catharsium.Calendar.Core.Logic.Scheduler;

public class AppointmentScheduler : IAppointmentScheduler
{
    private readonly IEnumerable<IAppointmentGenerator> appointmentGenerators;


    public AppointmentScheduler(IEnumerable<IAppointmentGenerator> appointmentGenerators)
    {
        this.appointmentGenerators = appointmentGenerators;
    }


    public async Task<Event[]> GenerateFor(DateTime fromDate, DateTime toDate, SchedulerSettings settings)
    {
        var result = new List<Event>();
        foreach(var appointment in settings.Appointments) {
            var generator = this.appointmentGenerators.FirstOrDefault(g => g.Interval == appointment.Recurrence.Interval);
            if(generator != null) {
                result.AddRange(await generator.GenerateFor(fromDate, toDate, appointment));
            }
        }

        return await Task.Run(() => result.ToArray());
    }
}