using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.Google.Tests._Configuration.AutoMapper._Fixture;
using Google.Apis.Calendar.v3.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Calendar.Google.Tests._Configuration.AutoMapper.MappingProfileTests
{
    [TestClass]
    public class DataMappingTests : MappingProfileFixture
    {
        [TestMethod]
        public void Map_CanMapEventDateTime_ToDate()
        {
            var eventDateTime = new EventDateTime {
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