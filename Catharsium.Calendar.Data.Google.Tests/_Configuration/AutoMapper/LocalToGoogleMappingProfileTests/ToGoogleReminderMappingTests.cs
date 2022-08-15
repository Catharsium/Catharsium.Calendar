using Catharsium.Clients.GoogleCalendar.Models;
using Catharsium.Clients.GoogleCalendar.Tests._Configuration.AutoMapper._Fixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoogleReminder = Google.Apis.Calendar.v3.Data.EventReminder;

namespace Catharsium.Clients.GoogleCalendar.Tests._Configuration.AutoMapper.LocalToGoogleMappingProfileTests;

[TestClass]
public class ToGoogleReminderMappingTests : LocalToGoogleMappingProfileFixture
{
    [TestMethod]
    public void Map_CanMapReminder_ToEventReminder()
    {
        var eventReminder = new Reminder {
            ETag = "My etag",
            Minutes = 99,
            Method = "My method"
        };

        var actual = this.Mapper.Map<GoogleReminder>(eventReminder);
        Assert.IsNotNull(actual);
        Assert.AreEqual(eventReminder.ETag, actual.ETag);
        Assert.AreEqual(eventReminder.Minutes, actual.Minutes);
        Assert.AreEqual(eventReminder.Method, actual.Method);
    }
}