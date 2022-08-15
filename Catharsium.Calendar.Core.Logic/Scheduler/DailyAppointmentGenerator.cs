using Catharsium.Calendar.Core.Entities.Models.Scheduler;
using Catharsium.Calendar.Core.Logic.Interfaces;
using Catharsium.Clients.GoogleCalendar.Interfaces;
using Catharsium.Clients.GoogleCalendar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catharsium.Calendar.Core.Logic.Scheduler;

public class DailyAppointmentGenerator : IAppointmentGenerator
{
    public Interval Interval => Interval.Daily;

    private readonly IEventManagementService eventManagementService;


    public DailyAppointmentGenerator(IEventManagementService eventManagementService)
    {
        this.eventManagementService = eventManagementService;
    }


    public async Task<Event[]> GenerateFor(DateTime fromDate, DateTime toDate, Appointment appointment)
    {
        var result = new List<Event>();
        var date = appointment.StartDate;

        while(date < toDate.AddDays(1)) {
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

            date = date.AddDays(appointment.Recurrence.Frequency);
        }

        return result.ToArray();
    }
}