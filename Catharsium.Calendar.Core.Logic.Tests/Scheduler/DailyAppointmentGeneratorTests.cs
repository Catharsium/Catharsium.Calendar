using Catharsium.Calendar.Core.Entities.Models.Scheduler;
using Catharsium.Calendar.Core.Logic.Scheduler;
using Catharsium.External.GoogleCalendar.Client.Interfaces;
using Catharsium.External.GoogleCalendar.Client.Models;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Threading.Tasks;

namespace Catharsium.Calendar.Core.Logic.Tests.Scheduler;

[TestClass]
public class DailyAppointmentGeneratorTests : TestFixture<DailyAppointmentGenerator>
{
    [TestMethod]
    public async Task GenerateFor_GeneratesAppointments_ReturnsEvents() {
        var appointment = new Appointment {
            CalendarId = "My calendar id",
            Category = "My category",
            Summary = "My description",
            StartDate = DateTime.Now,
            DurationInMinutes = 60,
            Recurrence = new Recurrence {
                Interval = Interval.Daily,
                Frequency = 1
            }
        };
        var daysToSchedule = 3;
        var startDate = DateTime.Today;
        var toDate = startDate.AddDays(daysToSchedule);
        var newEvent = new Event();
        this.GetDependency<IEventManagementService>().CreateEvent(
            appointment.CalendarId,
            Arg.Is<Event>(e =>
                e.Summary == appointment.Summary &&
                e.Location == appointment.Location &&
                e.Start.Value.TimeOfDay == appointment.StartDate.TimeOfDay &&
                e.Start.HasTime &&
                e.End.Value.TimeOfDay == appointment.StartDate.AddMinutes(appointment.DurationInMinutes).TimeOfDay &&
                e.End.HasTime
            )).Returns(newEvent);

        var actual = await this.Target.GenerateFor(startDate, toDate, appointment);
        Assert.AreEqual(daysToSchedule + 1, actual.Length);
    }


    [TestMethod]
    public async Task GenerateFor_Frequency7_GeneratesAppointmentEvery7Days() {
        var appointment = new Appointment {
            CalendarId = "My calendar id",
            Category = "My category",
            Summary = "My description",
            StartDate = DateTime.Now,
            DurationInMinutes = 60,
            Recurrence = new Recurrence {
                Interval = Interval.Daily,
                Frequency = 7
            }
        };
        var daysToSchedule = 123;
        var startDate = DateTime.Today;
        var toDate = startDate.AddDays(daysToSchedule).AddMinutes(appointment.DurationInMinutes);

        var actual = await this.Target.GenerateFor(startDate, toDate, appointment);
        Assert.AreEqual((daysToSchedule / appointment.Recurrence.Frequency) + 1, actual.Length);
    }
}