using Catharsium.Calendar.Core.Entities.Interfaces.Services;
using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.Data.Google.Client.Services;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Calendar.Data.Google.Tests.Client.Services.GoogleEventUpdateServiceTests
{
    [TestClass]
    public class MoveTests : TestFixture<GoogleEventUpdateService>
    {
        #region Fixture

        private Event Event { get; set; }


        [TestInitialize]
        public void SetupProperties()
        {
            this.Event = new Event {
                Id = "My event id",
                ICalUID = "My cal uid"
            };
        }

        #endregion

        [TestMethod]
        public void Move_CreatesEventOnNewCalendar_Successful_DeletesFromOld()
        {
            var oldCalendarId = "My old calendar id";
            var newCalendarId = "My new calendar id";
            var expected = new Event();
            this.GetDependency<IEventManagementService>().CreateEvent(newCalendarId, this.Event).Returns(expected);

            var actual = this.Target.Move(this.Event, oldCalendarId, newCalendarId);
            Assert.AreEqual(expected, actual);
            this.GetDependency<IEventManagementService>().Received().DeleteEvent(oldCalendarId, this.Event.Id);
        }


        [TestMethod]
        public void Move_CreatesEventOnNewCalendar_NotSuccessful_DoesNotDeleteFromOld()
        {
            var oldCalendarId = "My old calendar id";
            var newCalendarId = "My new calendar id";
            this.GetDependency<IEventManagementService>().CreateEvent(newCalendarId, this.Event).Returns(null as Event);

            var actual = this.Target.Move(this.Event, oldCalendarId, newCalendarId);
            Assert.IsNull(actual);
            this.GetDependency<IEventManagementService>().Received().DeleteEvent(oldCalendarId, this.Event.Id);
        }
    }
}