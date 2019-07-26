using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.Google.Tests._Configuration.AutoMapper._Fixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoogleOrganizer = Google.Apis.Calendar.v3.Data.Event.OrganizerData;

namespace Catharsium.Calendar.Google.Tests._Configuration.AutoMapper.GoogleToLocalMappingProfileTests
{
    [TestClass]
    public class ToGoogleOrganizerMappingTests : LocalToGoogleMappingProfileFixture
    {
        [TestMethod]
        public void Map_CanMapPerson_ToOrganizerData()
        {
            var organizerData = new Person
            {
                DisplayName = "My display name",
                Email = "My email",
                Id = "My id",
                Self = true
            };

            var actual = this.Mapper.Map<GoogleOrganizer>(organizerData);
            Assert.IsNotNull(actual);
            Assert.AreEqual(organizerData.DisplayName, actual.DisplayName);
            Assert.AreEqual(organizerData.Email, actual.Email);
            Assert.AreEqual(organizerData.Id, actual.Id);
            Assert.AreEqual(organizerData.Self, actual.Self);
        }
    }
}