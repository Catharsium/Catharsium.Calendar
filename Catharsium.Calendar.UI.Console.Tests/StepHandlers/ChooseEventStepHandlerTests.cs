using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.UI.Console.StepHandlers;
using Catharsium.Util.IO.Interfaces;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Calendar.UI.Console.Tests.StepHandlers
{
    [TestClass]
    public class ChooseEventStepHandlerTests : TestFixture<ChooseEventStepHandler>
    {
        [TestMethod]
        public void Run_ValidIndex_ReturnsEventAtIndex()
        {
            var index = 1;
            var events = new[] { new Event() };
            this.GetDependency<IConsole>().AskForInt().Returns(index);

            var actual = this.Target.Run(events);
            Assert.AreEqual(events[index - 1], actual);
        }


        [TestMethod]
        public void Run_NoIndex_ReturnsNull()
        {
            var events = new[] { new Event() };
            this.GetDependency<IConsole>().AskForInt().Returns(null as int?);

            var actual = this.Target.Run(events);
            Assert.IsNull(actual);
        }
    }
}