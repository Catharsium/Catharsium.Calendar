using System;
using Catharsium.Calendar.Core.Entities.Interfaces.Services;
using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.UI.Console.ActionHandlers;
using Catharsium.Calendar.UI.Console.Interfaces;
using Catharsium.Util.IO.Interfaces;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Calendar.UI.Console.Tests.ActionHandlers
{
    [TestClass]
    public class CreateEventActionHandlerTests : TestFixture<CreateEventActionHandler>
    {
        #region Fixture

        private string Summary { get; set; }
        private DateTime StartDate { get; set; }
        private DateTime EndDate { get; set; }


        [TestInitialize]
        public void SetupProperties()
        {
            ;
            this.Summary = "My summary";
            this.StartDate = DateTime.Now;
            this.EndDate = DateTime.Now.AddHours(1);
        }


        #endregion

        [TestMethod]
        public void Run_ValidStartAndEndDate_CreatesEvent()
        {
            this.GetDependency<IConsole>().AskForText(Arg.Any<string>()).Returns(this.Summary);
            this.GetDependency<IConsole>().AskForDate(Arg.Is<string>(s => s.Contains("start date"))).Returns(this.StartDate);
            this.GetDependency<IConsole>().AskForDate(Arg.Is<string>(s => s.Contains("end date"))).Returns(this.EndDate);
            var calendar = new Core.Entities.Models.Calendar {Id = "My calendar id"};
            this.GetDependency<IChooseCalendarStepHandler>().Run().Returns(calendar);

            this.Target.Run();
            this.GetDependency<IEventManagementService>().Received().CreateEvent(
                calendar.Id,
                Arg.Is<Event>(e => e.Summary == this.Summary &&
                                   e.Start.Value == this.StartDate &&
                                   e.End.Value == this.EndDate));
        }


        [TestMethod]
        public void Run_InvalidStartDate_DoesNotCreateEvent()
        {
            this.GetDependency<IConsole>().AskForText(Arg.Any<string>()).Returns(this.Summary);
            this.GetDependency<IConsole>().AskForDate(Arg.Is<string>(s => s.Contains("start date"))).Returns(null as DateTime?);
            this.GetDependency<IConsole>().AskForDate(Arg.Is<string>(s => s.Contains("end date"))).Returns(this.EndDate);
            var calendar = new Core.Entities.Models.Calendar {Id = "My calendar id"};
            this.GetDependency<IChooseCalendarStepHandler>().Run().Returns(calendar);

            this.Target.Run();
            this.GetDependency<IEventManagementService>().DidNotReceive().CreateEvent(Arg.Any<string>(), Arg.Any<Event>());
        }


        [TestMethod]
        public void Run_InvalidEndDate_DoesNotCreateEvent()
        {
            this.GetDependency<IConsole>().AskForText(Arg.Any<string>()).Returns(this.Summary);
            this.GetDependency<IConsole>().AskForDate(Arg.Is<string>(s => s.Contains("start date"))).Returns(this.StartDate);
            this.GetDependency<IConsole>().AskForDate(Arg.Is<string>(s => s.Contains("end date"))).Returns(null as DateTime?);
            var calendar = new Core.Entities.Models.Calendar {Id = "My calendar id"};
            this.GetDependency<IChooseCalendarStepHandler>().Run().Returns(calendar);

            this.Target.Run();
            this.GetDependency<IEventManagementService>().DidNotReceive().CreateEvent(Arg.Any<string>(), Arg.Any<Event>());
        }


        [TestMethod]
        public void Run_InvalidCalendar_DoesNotCreateEvent()
        {
            this.GetDependency<IConsole>().AskForText(Arg.Any<string>()).Returns(this.Summary);
            this.GetDependency<IConsole>().AskForDate(Arg.Is<string>(s => s.Contains("start date"))).Returns(this.StartDate);
            this.GetDependency<IConsole>().AskForDate(Arg.Is<string>(s => s.Contains("end date"))).Returns(this.EndDate);
            this.GetDependency<IChooseCalendarStepHandler>().Run().Returns(null as Core.Entities.Models.Calendar);

            this.Target.Run();
            this.GetDependency<IEventManagementService>().DidNotReceive().CreateEvent(Arg.Any<string>(), Arg.Any<Event>());
        }
    }
}