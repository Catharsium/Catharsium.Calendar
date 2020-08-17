using Catharsium.Calendar.Data.Google.Interfaces;
using Catharsium.Calendar.UI.Console.StepHandlers;
using Catharsium.Util.IO.Console.Interfaces;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Calendar.UI.Console.Tests.StepHandlers
{
    [TestClass]
    public class ChooseAccountStepHandlerTests : TestFixture<ChooseAccountStepHandler>
    {
        [TestMethod]
        public void Run_WritesStoredUserNames()
        {
            var index = 1;
            var userNames = new[] {"My first user name", "My second user name", "My third user name"};
            var calendarClientFactory = Substitute.For<ICalendarClientFactory>();
            calendarClientFactory.GetUserNames().Returns(userNames);
            this.SetDependency(calendarClientFactory);
            this.GetDependency<IConsole>().AskForInt().Returns(index);

            this.Target.Run();
            foreach (var userName in userNames) {
                this.GetDependency<IConsole>().Received().WriteLine(Arg.Is<string>(s => s.Contains(userName)));
            }
        }


        [TestMethod]
        public void Run_ValidUserIndex_ReturnsUserName()
        {
            var index = 1;
            var userNames = new[] {"My user name"};
            var calendarClientFactory = Substitute.For<ICalendarClientFactory>();
            calendarClientFactory.GetUserNames().Returns(userNames);
            this.SetDependency(calendarClientFactory);
            this.GetDependency<IConsole>().AskForInt().Returns(index);

            var actual = this.Target.Run();
            Assert.AreEqual(userNames[index - 1], actual);
        }


        [TestMethod]
        public void Run_NoUserIndex_ReturnsNull()
        {
            var userNames = new[] {"My user name"};
            var calendarClientFactory = Substitute.For<ICalendarClientFactory>();
            calendarClientFactory.GetUserNames().Returns(userNames);
            this.SetDependency(calendarClientFactory);
            this.GetDependency<IConsole>().AskForInt().Returns(null as int?);
            this.Setup();

            var actual = this.Target.Run();
            Assert.IsNull(actual);
        }
    }
}