using Catharsium.Calendar.Core.Entities.Interfaces.Services;
using Catharsium.Calendar.UI.Console.StepHandlers;
using Catharsium.Util.IO.Interfaces;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Calendar.UI.Console.Tests.StepHandlers
{
    [TestClass]
    public class ChooseCalendarStepHandlerTests : TestFixture<ChooseCalendarStepHandler>
    {
        [TestMethod]
        public void Run_WritesCalendars()
        {
            var index = 1;
            this.GetDependency<IConsole>().AskForInt().Returns(index);
            var calendars = new[] {
                new Core.Entities.Models.Calendar {Summary = "My first calendar"},
                new Core.Entities.Models.Calendar {Summary = "My second calendar"}
            };
            this.GetDependency<ICalendarService>().GetList().Returns(calendars);

            this.Target.Run();
            foreach (var calendar in calendars) {
                this.GetDependency<IConsole>().Received().WriteLine(Arg.Is<string>(s => s.Contains(calendar.Summary)));
            }
        }


        [TestMethod]
        public void Run_ValidCalendarIndex_ReturnsCalendar()
        {
            var index = 1;
            this.GetDependency<IConsole>().AskForInt().Returns(index);
            var calendars = new[] {
                new Core.Entities.Models.Calendar {Summary = "My first calendar"},
                new Core.Entities.Models.Calendar {Summary = "My second calendar"}
            };
            this.GetDependency<ICalendarService>().GetList().Returns(calendars);

            var actual = this.Target.Run();
            Assert.AreEqual(calendars[index - 1], actual);
        }


        [TestMethod]
        public void Run_NoCalendarIndex_ReturnsCalendar()
        {
            this.GetDependency<IConsole>().AskForInt().Returns(null as int?);
            var calendars = new[] {
                new Core.Entities.Models.Calendar {Summary = "My first calendar"},
                new Core.Entities.Models.Calendar {Summary = "My second calendar"}
            };
            this.GetDependency<ICalendarService>().GetList().Returns(calendars);

            var actual = this.Target.Run();
            Assert.IsNull(actual);
        }
    }
}