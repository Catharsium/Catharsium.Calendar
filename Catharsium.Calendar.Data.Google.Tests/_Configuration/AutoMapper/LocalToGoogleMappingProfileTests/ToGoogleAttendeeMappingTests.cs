using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.Data.Google.Tests._Configuration.AutoMapper._Fixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoogleAttendee = Google.Apis.Calendar.v3.Data.EventAttendee;

namespace Catharsium.Calendar.Data.Google.Tests._Configuration.AutoMapper.LocalToGoogleMappingProfileTests
{
    [TestClass]
    public class ToGoogleAttendeeMappingTests : LocalToGoogleMappingProfileFixture
    {
        [TestMethod]
        public void Map_CanMapAttendee_ToEventAttendee()
        {
            var calendar = new Attendee {
                AdditionalGuests = 9,
                Comment = "My comment",
                DisplayName = "My display name",
                Email = "My email",
                ETag = "My etag",
                Id = "My id",
                Optional = true,
                Organizer = true,
                Resource = true,
                ResponseStatus = "My response status",
                Self = true
            };

            var actual = this.Mapper.Map<GoogleAttendee>(calendar);
            Assert.IsNotNull(actual);
            Assert.AreEqual(calendar.AdditionalGuests, actual.AdditionalGuests);
            Assert.AreEqual(calendar.Comment, actual.Comment);
            Assert.AreEqual(calendar.DisplayName, actual.DisplayName);
            Assert.AreEqual(calendar.Email, actual.Email);
            Assert.AreEqual(calendar.ETag, actual.ETag);
            Assert.AreEqual(calendar.Id, actual.Id);
            Assert.AreEqual(calendar.Optional, actual.Optional);
            Assert.AreEqual(calendar.Organizer, actual.Organizer);
            Assert.AreEqual(calendar.Resource, actual.Resource);
            Assert.AreEqual(calendar.ResponseStatus, actual.ResponseStatus);
            Assert.AreEqual(calendar.Self, actual.Self);
        }
    }
}