using Catharsium.Calendar.Core.Entities.Interfaces.Services;
using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.Core.Entities.Models.Scheduler;
using Catharsium.Calendar.Core.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catharsium.Calendar.Core.Logic.Scheduler
{
    public class AppointmentScheduler : IAppointmentScheduler
    {
        private readonly IEventManagementService eventManagementService;


        public AppointmentScheduler(IEventManagementService eventManagementService)
        {
            this.eventManagementService = eventManagementService;
        }


        public async Task<Event[]> GenerateFor(DateTime fromDate, DateTime toDate, SchedulerSettings settings)
        {
            var result = new List<Event>();
            foreach (var appointment in settings.Appointments) {
                result.AddRange(await this.GenerateFor(fromDate, toDate, appointment));
            }

            return await Task.Run(() => result.ToArray());
        }


        public async Task<Event[]> GenerateFor(DateTime fromDate, DateTime toDate, Appointment appointment)
        {
            var result = new List<Event>();
            var date = fromDate.Date + appointment.StartTime;

            while (date <= toDate) {
                result.Add(await this.eventManagementService.CreateEvent(appointment.CalendarId, new Event {
                    Summary = appointment.Summary,
                    Location = appointment.Location,
                    Start = new Date {Value = date, HasTime = true},
                    End = new Date {Value = date.AddMinutes(appointment.DurationInMinutes), HasTime = true},
                    //  ColorId = appointment.Category
                }));
                date = date.AddDays(1);
            }

            return result.ToArray();
        }
    }
}