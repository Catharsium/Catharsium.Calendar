using Catharsium.Clients.GoogleCalendar.Tests._Configuration.AutoMapper._Fixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoogleListEntry = Google.Apis.Calendar.v3.Data.CalendarListEntry;

namespace Catharsium.Clients.GoogleCalendar.Tests._Configuration.AutoMapper.LocalToGoogleMappingProfileTests;

[TestClass]
public class ToGoogleCalendarMappingTests : LocalToGoogleMappingProfileFixture
{
    [TestMethod]
    public void Map_CanMapCalendar_ToCalendarListEntry()
    {
        var calendar = new Models.Calendar {
            Id = "My id"
        };

        var actual = this.Mapper.Map<GoogleListEntry>(calendar);
        Assert.IsNotNull(actual);
        Assert.AreEqual(calendar.Id, actual.Id);
    }
}