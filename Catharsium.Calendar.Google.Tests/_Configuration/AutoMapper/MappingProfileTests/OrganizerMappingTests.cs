using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.Google.Tests._Configuration.AutoMapper._Fixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Event = Google.Apis.Calendar.v3.Data.Event;

namespace Catharsium.Calendar.Google.Tests._Configuration.AutoMapper.MappingProfileTests
{
    [TestClass]
    public class OrganizerMappingTests : MappingProfileFixture
    {
        [TestMethod]
        public void Map_CanMapGoogleCalendarOrganizerData_ToPerson()
        {
            var organizerData = new Event.OrganizerData {
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
}