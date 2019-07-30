using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.Core.Entities.Models.Comparers;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Calendar.Core.Entities.Tests.Models.Comparers.EventEqualityComparerTests
{
    [TestClass]
    public class EqualsTests : TestFixture<EventEqualityComparer>
    {
        [TestMethod]
        public void Equals_EventAndNull_ReturnsFalse()
        {
            var otherEvent = new Event();
            var actual = this.Target.Equals(otherEvent, null);
            Assert.IsFalse(actual);
        }


        [TestMethod]
        public void Equals_NullAndEvent_ReturnsFalse()
        {
            var otherEvent = new Event();
            var actual = this.Target.Equals(null, otherEvent);
            Assert.IsFalse(actual);
        }


        [TestMethod]
        public void Equals_EventWithDifferentId_ReturnsFalse()
        {
            var eventData = new Event { Id = "My id" };
            var otherEvent = new Event { Id = eventData.Id + "Other" };
            var actual = this.Target.Equals(eventData, otherEvent);
            Assert.IsFalse(actual);
        }


        [TestMethod]
        public void Equals_EventWithSameId_ReturnsTrue()
        {
            var eventData = new Event { Id = "My id" };
            var otherEvent = new Event { Id = eventData.Id };
            var actual = this.Target.Equals(eventData, otherEvent);
            Assert.IsTrue(actual);
        }
    }
}