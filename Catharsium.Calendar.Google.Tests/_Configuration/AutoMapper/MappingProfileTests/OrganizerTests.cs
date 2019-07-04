using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.Google.Tests._Configuration.AutoMapper._Fixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Event = Google.Apis.Calendar.v3.Data.Event;

namespace Catharsium.Calendar.Google.Tests._Configuration.AutoMapper.MappingProfileTests
{
    [TestClass]
    public class OrganizerTests : MappingProfileFixture
    {
        [TestMethod]
        public void Map_CanMapGoogleCalendarOrganizerData_ToPerson()
        {
            var organizerData = new Event.OrganizerData {
                Email = "My email"
            };

            var actual = this.Mapper.Map<Person>(organizerData);
            Assert.IsNotNull(actual);
            Assert.AreEqual(organizerData.Email, actual.Email);
        }
    }
}