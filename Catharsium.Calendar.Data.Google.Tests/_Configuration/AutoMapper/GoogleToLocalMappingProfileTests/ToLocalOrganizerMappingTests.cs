using Catharsium.Clients.GoogleCalendar.Models;
using Catharsium.Clients.GoogleCalendar.Tests._Configuration.AutoMapper._Fixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoogleOrganizer = Google.Apis.Calendar.v3.Data.Event.OrganizerData;

namespace Catharsium.Clients.GoogleCalendar.Tests._Configuration.AutoMapper.GoogleToLocalMappingProfileTests;

[TestClass]
public class ToLocalOrganizerMappingTests : GoogleToLocalMappingProfileFixture
{
    [TestMethod]
    public void Map_CanMapOrganizerData_ToPerson()
    {
        var organizerData = new GoogleOrganizer {
            DisplayName = "My display name",
            Email = "My email",
            Id = "My id",
            Self = true
        };

        var actual = this.Mapper.Map<Person>(organizerData);
        Assert.IsNotNull(actual);
        Assert.AreEqual(organizerData.DisplayName, actual.DisplayName);
        Assert.AreEqual(organizerData.Email, actual.Email);
        Assert.AreEqual(organizerData.Id, actual.Id);
        Assert.AreEqual(organizerData.Self, actual.Self);
    }
}