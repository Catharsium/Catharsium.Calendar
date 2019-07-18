using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.Google.Tests._Configuration.AutoMapper._Fixture;
using Google.Apis.Calendar.v3.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Calendar.Google.Tests._Configuration.AutoMapper.MappingProfileTests
{
    [TestClass]
    public class AttachmentMappingTests : MappingProfileFixture
    {
        [TestMethod]
        public void Map_CanMapEventAttachment_ToAttachment()
        {
            var sourceData = new EventAttachment {
                FileId = "My file id",
                FileUrl = "My file url",
                IconLink = "My icon link",
                MimeType = "My mime type",
                Title = "My title",
                ETag = "My etag"
            };

            var actual = this.Mapper.Map<Attachment>(sourceData);
            Assert.IsNotNull(actual);
            Assert.AreEqual(sourceData.FileId, actual.FileId);
            Assert.AreEqual(sourceData.FileUrl, actual.FileUrl);
            Assert.AreEqual(sourceData.IconLink, actual.IconLink);
            Assert.AreEqual(sourceData.MimeType, actual.MimeType);
            Assert.AreEqual(sourceData.Title, actual.Title);
            Assert.AreEqual(sourceData.ETag, actual.ETag);
        }
    }
}