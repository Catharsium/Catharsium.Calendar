using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.Core.Entities.Models.Scheduler;
using Catharsium.Calendar.Core.Logic.Interfaces;
using Catharsium.Calendar.Core.Logic.Scheduler;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catharsium.Calendar.Core.Logic.Tests.Scheduler
{
    [TestClass]
    public class AppointmentSchedulerTests : TestFixture<AppointmentScheduler>
    {
        [TestMethod]
        public async Task GenerateFor_UsesCorrectGeneratorForEachAppointment()
        {
            var fromDate = DateTime.Today;
            var toDate = fromDate.AddDays(1);

            var settings = new SchedulerSettings {
                Appointments = new[] {
                    new Appointment {Recurrence = new Recurrence {Interval = Interval.Daily}},
                    new Appointment {Recurrence = new Recurrence {Interval = Interval.Monthly}},
                    new Appointment {Recurrence = new Recurrence {Interval = Interval.Annually}}
                }
            };

            var dailyAppointments = new[] {new Event()};
            var dailyGenerator = Substitute.For<IAppointmentGenerator>();
            dailyGenerator.Interval.Returns(Interval.Daily);
            dailyGenerator.GenerateFor(fromDate, toDate, settings.Appointments[0]).Returns(dailyAppointments);
            var monthlyAppointments = new[] {new Event()};
            var monthlyGenerator = Substitute.For<IAppointmentGenerator>();
            monthlyGenerator.Interval.Returns(Interval.Monthly); 
            monthlyGenerator.GenerateFor(fromDate, toDate, settings.Appointments[1]).Returns(monthlyAppointments);
            var annuallyGenerator = Substitute.For<IAppointmentGenerator>();
            var annuallyAppointments = new[] {new Event()};
            annuallyGenerator.Interval.Returns(Interval.Annually);
            this.SetDependency<IEnumerable<IAppointmentGenerator>>(new[] {dailyGenerator, monthlyGenerator, annuallyGenerator});
            annuallyGenerator.GenerateFor(fromDate, toDate, settings.Appointments[2]).Returns(annuallyAppointments);

            var actual = await this.Target.GenerateFor(fromDate, toDate, settings);
            foreach (var appointment in dailyAppointments)
            {
                Assert.IsTrue(actual.Contains(appointment));
            }
            foreach (var appointment in monthlyAppointments)
            {
                Assert.IsTrue(actual.Contains(appointment));
            }
            foreach (var appointment in annuallyAppointments)
            {
                Assert.IsTrue(actual.Contains(appointment));
            }
        }
    }
}