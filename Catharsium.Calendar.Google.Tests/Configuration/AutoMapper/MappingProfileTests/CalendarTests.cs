using Catharsium.Calendar.Google.Tests.Configuration.AutoMapper.MappingProfileTests;
using Google.Apis.Calendar.v3.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Calendar.Google.Tests.Configuration.AutoMapper
{
    [TestClass]
    public class CalendarTests : MappingProfileFixture
    {
        [TestMethod]
        public void Map_CanMapGoogleCalendarListEntry_ToCalendar()
        {
            var calendar = new CalendarListEntry {
                Id = "My id"
            };

            var actual = this.Mapper.Map<Core.Entities.Models.Calendar>(calendar);
            Assert.IsNotNull(actual);
            Assert.AreEqual(calendar.Id, actual.Id);
        }
    }
}