using Catharsium.Clients.GoogleCalendar.Models;
using Catharsium.Clients.GoogleCalendar.Tests._Configuration.AutoMapper._Fixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoogleAttachment = Google.Apis.Calendar.v3.Data.EventAttachment;

namespace Catharsium.Clients.GoogleCalendar.Tests._Configuration.AutoMapper.LocalToGoogleMappingProfileTests;

[TestClass]
public class ToGoogleAttachmentMappingTests : LocalToGoogleMappingProfileFixture
{
    [TestMethod]
    public void Map_CanMapAttachment_ToEventAttachment()
    {
        var sourceData = new Attachment {
            FileId = "My file id",
            FileUrl = "My file url",
            IconLink = "My icon link",
            MimeType = "My mime type",
            Title = "My title",
            ETag = "My etag"
        };

        var actual = this.Mapper.Map<GoogleAttachment>(sourceData);
        Assert.IsNotNull(actual);
        Assert.AreEqual(sourceData.FileId, actual.FileId);
        Assert.AreEqual(sourceData.FileUrl, actual.FileUrl);
        Assert.AreEqual(sourceData.IconLink, actual.IconLink);
        Assert.AreEqual(sourceData.MimeType, actual.MimeType);
        Assert.AreEqual(sourceData.Title, actual.Title);
        Assert.AreEqual(sourceData.ETag, actual.ETag);
    }
}