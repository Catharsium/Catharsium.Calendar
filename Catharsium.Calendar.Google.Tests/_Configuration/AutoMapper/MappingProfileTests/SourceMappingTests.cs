using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.Google.Tests._Configuration.AutoMapper._Fixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Event = Google.Apis.Calendar.v3.Data.Event;

namespace Catharsium.Calendar.Google.Tests._Configuration.AutoMapper.MappingProfileTests
{
    [TestClass]
    public class SourceMappingTests : MappingProfileFixture
    {
        [TestMethod]
        public void Map_CanMapEventSource_ToSource()
        {
            var sourceData = new Event.SourceData {
                Title = "My title",
                Url = "My url"
            };

            var actual = this.Mapper.Map<Source>(sourceData);
            Assert.IsNotNull(actual);
            Assert.AreEqual(sourceData.Title, actual.Title);
            Assert.AreEqual(sourceData.Url, actual.Url);
        }
    }
}