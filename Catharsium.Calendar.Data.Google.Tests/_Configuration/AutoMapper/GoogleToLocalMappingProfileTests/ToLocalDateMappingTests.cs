using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.Data.Google.Tests._Configuration.AutoMapper._Fixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoogleDate = Google.Apis.Calendar.v3.Data.EventDateTime;

namespace Catharsium.Calendar.Data.Google.Tests._Configuration.AutoMapper.GoogleToLocalMappingProfileTests
{
    [TestClass]
    public class ToLocalDateMappingTests : GoogleToLocalMappingProfileFixture
    {
        [TestMethod]
        public void Map_CanMapEventDateTime_ToDate()
        {
            var eventDateTime = new GoogleDate {
                ETag = "My etag",
                TimeZone = "My time zone"
            };

            var actual = this.Mapper.Map<Date>(eventDateTime);
            Assert.IsNotNull(actual);
            Assert.AreEqual(eventDateTime.ETag, actual.ETag);
            Assert.AreEqual(eventDateTime.TimeZone, actual.TimeZone);
        }
    }
}