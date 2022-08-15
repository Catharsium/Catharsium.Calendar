using Catharsium.Clients.GoogleCalendar.Models;
using Catharsium.Clients.GoogleCalendar.Tests._Configuration.AutoMapper._Fixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoogleDate = Google.Apis.Calendar.v3.Data.EventDateTime;

namespace Catharsium.Clients.GoogleCalendar.Tests._Configuration.AutoMapper.LocalToGoogleMappingProfileTests;

[TestClass]
public class ToGoogleDataMappingTests : LocalToGoogleMappingProfileFixture
{
    [TestMethod]
    public void Map_CanMapDate_ToEventDateTime()
    {
        var eventDateTime = new Date {
            ETag = "My etag",
            TimeZone = "My time zone"
        };

        var actual = this.Mapper.Map<GoogleDate>(eventDateTime);
        Assert.IsNotNull(actual);
        Assert.AreEqual(eventDateTime.ETag, actual.ETag);
        Assert.AreEqual(eventDateTime.TimeZone, actual.TimeZone);
    }
}