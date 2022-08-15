using Catharsium.Clients.GoogleCalendar.Models;
using Catharsium.Clients.GoogleCalendar.Tests._Configuration.AutoMapper._Fixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoogleSource = Google.Apis.Calendar.v3.Data.Event.SourceData;

namespace Catharsium.Clients.GoogleCalendar.Tests._Configuration.AutoMapper.LocalToGoogleMappingProfileTests;

[TestClass]
public class ToGoogleSourceMappingTests : LocalToGoogleMappingProfileFixture
{
    [TestMethod]
    public void Map_CanMapEventSource_ToSource()
    {
        var sourceData = new Source {
            Title = "My title",
            Url = "My url"
        };

        var actual = this.Mapper.Map<GoogleSource>(sourceData);
        Assert.IsNotNull(actual);
        Assert.AreEqual(sourceData.Title, actual.Title);
        Assert.AreEqual(sourceData.Url, actual.Url);
    }
}