using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.Google.Tests._Configuration.AutoMapper._Fixture;
using Google.Apis.Calendar.v3.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Calendar.Google.Tests._Configuration.AutoMapper.MappingProfileTests
{
    [TestClass]
    public class ReminderTests : MappingProfileFixture
    {
        [TestMethod]
        public void Map_CanMapGoogleCalendarEventReminder_ToReminder()
        {
            var eventReminder = new EventReminder {
                Minutes = 99
            };

            var actual = this.Mapper.Map<Reminder>(eventReminder);
            Assert.IsNotNull(actual);
            Assert.AreEqual(eventReminder.Minutes, actual.Minutes);
        }
    }
}