using Catharsium.Calendar.Data.Google.Tests._Configuration.AutoMapper._Fixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoogleListEntry = Google.Apis.Calendar.v3.Data.CalendarListEntry;

namespace Catharsium.Calendar.Data.Google.Tests._Configuration.AutoMapper.GoogleToLocalMappingProfileTests
{
    [TestClass]
    public class ToLocalCalendarMappingTests : GoogleToLocalMappingProfileFixture
    {
        [TestMethod]
        public void Map_CanMapGoogleCalendarListEntry_ToCalendar()
        {
            var calendar = new GoogleListEntry {
                Id = "My id"
            };

            var actual = this.Mapper.Map<Core.Entities.Models.Calendar>(calendar);
            Assert.IsNotNull(actual);
            Assert.AreEqual(calendar.Id, actual.Id);
        }
    }
}