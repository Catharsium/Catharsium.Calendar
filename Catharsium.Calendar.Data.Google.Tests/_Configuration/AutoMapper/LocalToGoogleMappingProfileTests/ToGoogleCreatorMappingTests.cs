using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.Data.Google.Tests._Configuration.AutoMapper._Fixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoogleCreatorData = Google.Apis.Calendar.v3.Data.Event.CreatorData;

namespace Catharsium.Calendar.Data.Google.Tests._Configuration.AutoMapper.LocalToGoogleMappingProfileTests
{
    [TestClass]
    public class ToGoogleCreatorMappingTests : LocalToGoogleMappingProfileFixture
    {
        [TestMethod]
        public void Map_CanMapPerson_ToCreatorData()
        {
            var creatorData = new Person {
                DisplayName = "My display name",
                Email = "My email",
                Id = "My id",
                Self = true
            };

            var actual = this.Mapper.Map<GoogleCreatorData>(creatorData);
            Assert.IsNotNull(actual);
            Assert.AreEqual(creatorData.DisplayName, actual.DisplayName);
            Assert.AreEqual(creatorData.Email, actual.Email);
            Assert.AreEqual(creatorData.Id, actual.Id);
            Assert.AreEqual(creatorData.Self, actual.Self);
        }
    }
}