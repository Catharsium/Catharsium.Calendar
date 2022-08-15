using Catharsium.Calendar.Core.Entities.Models.Scheduler;
using Catharsium.Calendar.Core.Logic.Interfaces;
using Catharsium.Clients.GoogleCalendar.Interfaces;
using Catharsium.Clients.GoogleCalendar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catharsium.Calendar.Core.Logic.Scheduler;

public class MonthlyAppointmentGenerator : IAppointmentGenerator
{
    public Interval Interval => Interval.Monthly;

    private readonly IEventManagementService eventManagementService;


    public MonthlyAppointmentGenerator(IEventManagementService eventManagementService)
    {
        this.eventManagementService = eventManagementService;
    }


    public async Task<Event[]> GenerateFor(DateTime fromDate, DateTime toDate, Appointment appointment)
    {
        var result = new List<Event>();
        var date = appointment.StartDate;

        while(date < toDate.AddMonths(1)) {
            if(date > fromDate) {
                var existingAppointments = await this.eventManagementService.GetList(appointment.CalendarId, date, date.AddMinutes(appointment.DurationInMinutes));
                if(!existingAppointments.Any(e =>
                    e.Summary == appointment.Summary &&
                    e.Location == appointment.Location
                )) {
                    result.Add(await this.eventManagementService.CreateEvent(appointment.CalendarId, new Event {
                        Summary = appointment.Summary,
                        Location = appointment.Location,
                        Start = new Date { Value = date, HasTime = true },
                        End = new Date { Value = date.AddMinutes(appointment.DurationInMinutes), HasTime = true }
                    }));
                }
            }

            date = date.AddMonths(appointment.Recurrence.Frequency);
        }

        return result.ToArray();
    }
}