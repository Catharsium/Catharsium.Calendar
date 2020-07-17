using Catharsium.Calendar.Core.Entities.Interfaces.Services;
using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.Core.Entities.Models.Scheduler;
using Catharsium.Calendar.Core.Logic.Scheduler;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;

namespace Catharsium.Calendar.Core.Logic.Tests.Scheduler
{
    [TestClass]
    public class AppointmentSchedulerTests : TestFixture<AppointmentScheduler>
    {
        [TestMethod]
        [Ignore]
        public void GenerateFor_()
        {
            var settings = new SchedulerSettings {
                Appointments = new[] {
                    new Appointment {
                        CalendarId = "My calendar id",
                        Category = "My category",
                        Summary = "My description",
                        Recurrence = "Daily"
                    }
                }
            };
            var startDate = DateTime.Today;
            var toDate = startDate.AddDays(6);

            var actual = this.Target.GenerateFor(startDate, toDate, settings);
            var date = startDate;
            foreach (var appointment in settings.Appointments) {
                while (date <= toDate) {
                    this.GetDependency<IEventManagementService>().Received().CreateEvent(
                        appointment.CalendarId,
                        Arg.Is<Event>(e =>
                                e.Description == appointment.Summary &&
                            e.Location == appointment.Location// &&
                            //e.Start == new Date {Value = date, HasTime = true}// &&
                            //e.End == new Date {Value = date.AddHours(1), HasTime = true}
                        ));
                    date = date.AddDays(1);
                }
            }
        }
    }
}