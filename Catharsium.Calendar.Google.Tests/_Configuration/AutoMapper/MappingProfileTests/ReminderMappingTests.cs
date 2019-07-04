using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.Google.Tests._Configuration.AutoMapper._Fixture;
using Google.Apis.Calendar.v3.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Calendar.Google.Tests._Configuration.AutoMapper.MappingProfileTests
{
    [TestClass]
    public class ReminderMappingTests : MappingProfileFixture
    {
        [TestMethod]
        public void Map_CanMapEventReminder_ToReminder()
        {
            var eventReminder = new EventReminder {
                ETag = "My etag",
                Minutes = 99,
                Method = "My method"
            };

            var actual = this.Mapper.Map<Reminder>(eventReminder);
            Assert.IsNotNull(actual);
            Assert.AreEqual(eventReminder.ETag, actual.ETag);
            Assert.AreEqual(eventReminder.Minutes, actual.Minutes);
            Assert.AreEqual(eventReminder.Method, actual.Method);
        }
    }
}