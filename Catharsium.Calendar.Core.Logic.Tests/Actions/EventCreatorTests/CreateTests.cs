using Catharsium.Calendar.Core.Entities.Interfaces;
using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.Core.Logic.Actions;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Calendar.Core.Logic.Tests.Actions.EventCreatorTests
{
    [TestClass]
    public class CreateTests : TestFixture<EventCreator>
    {
        #region Fixture

        private Event Event { get; set; }


        [TestInitialize]
        public void SetupProperties()
        {
            this.Event = new Event();
        }

        #endregion

        [TestMethod]
        public void Create_Event_ReturnsNewEvent()
        {
            var calendarId = "My new calendar id";
            var expected = new Event();
            this.GetDependency<IEventService>().CreateEvent(calendarId, this.Event).Returns(expected);

            var actual = this.Target.Create(this.Event, calendarId);
            Assert.AreEqual(expected, actual);
        }
    }
}