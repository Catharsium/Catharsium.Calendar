using Catharsium.Calendar.Google.Tests._Configuration.AutoMapper._Fixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoogleListEntry = Google.Apis.Calendar.v3.Data.CalendarListEntry;

namespace Catharsium.Calendar.Google.Tests._Configuration.AutoMapper.GoogleToLocalMappingProfileTests
{
    [TestClass]
    public class ToGoogleCalendarMappingTests : LocalToGoogleMappingProfileFixture
    {
        [TestMethod]
        public void Map_CanMapCalendar_ToCalendarListEntry()
        {
            var calendar = new Core.Entities.Models.Calendar
            {
                Id = "My id"
            };

            var actual = this.Mapper.Map<GoogleListEntry>(calendar);
            Assert.IsNotNull(actual);
            Assert.AreEqual(calendar.Id, actual.Id);
        }
    }
}