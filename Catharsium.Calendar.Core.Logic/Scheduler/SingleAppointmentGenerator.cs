using Catharsium.Calendar.Core.Entities.Models.Scheduler;
using Catharsium.Calendar.Core.Logic.Interfaces;
using Catharsium.External.GoogleCalendar.Client.Interfaces;
using Catharsium.External.GoogleCalendar.Client.Models;
using System;
using System.Threading.Tasks;

namespace Catharsium.Calendar.Core.Logic.Scheduler;

public class SingleAppointmentGenerator : IAppointmentGenerator
{
    private readonly IEventManagementService eventManagementService;

    public Interval Interval => Interval.Single;


    public SingleAppointmentGenerator(IEventManagementService eventManagementService) {
        this.eventManagementService = eventManagementService;
    }


    public async Task<Event[]> GenerateFor(DateTime fromDate, DateTime toDate, Appointment appointment) {
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