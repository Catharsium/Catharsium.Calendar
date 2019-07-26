using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.Google.Tests._Configuration.AutoMapper._Fixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoogleSource = Google.Apis.Calendar.v3.Data.Event.SourceData;

namespace Catharsium.Calendar.Google.Tests._Configuration.AutoMapper.GoogleToLocalMappingProfileTests
{
    [TestClass]
    public class ToLocalSourceMappingTests : GoogleToLocalMappingProfileFixture
    {
        [TestMethod]
        public void Map_CanMapEventSource_ToSource()
        {
            var sourceData = new GoogleSource
            {
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