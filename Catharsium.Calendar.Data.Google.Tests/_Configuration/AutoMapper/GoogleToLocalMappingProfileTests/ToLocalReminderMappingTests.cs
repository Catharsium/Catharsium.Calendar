using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.Data.Google.Tests._Configuration.AutoMapper._Fixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoogleReminder = Google.Apis.Calendar.v3.Data.EventReminder;

namespace Catharsium.Calendar.Data.Google.Tests._Configuration.AutoMapper.GoogleToLocalMappingProfileTests
{
    [TestClass]
    public class ToLocalReminderMappingTests : GoogleToLocalMappingProfileFixture
    {
        [TestMethod]
        public void Map_CanMapEventReminder_ToReminder()
        {
            var eventReminder = new GoogleReminder {
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