using Catharsium.Calendar.Core.Entities.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoogleEvent = Google.Apis.Calendar.v3.Data.Event;

namespace Catharsium.Calendar.Google.Tests.Configuration.AutoMapper.MappingProfileTests
{
    [TestClass]
    public class EventTests : MappingProfileFixture
    {
        [TestMethod]
        public void Map_CanMapGoogleEvent_ToEvent()
        {
            var calendar = new GoogleEvent
            {
                Id = "My id"
            };

            var actual = this.Mapper.Map<Event>(calendar);
            Assert.IsNotNull(actual);
            Assert.AreEqual(calendar.Id, actual.Id);
        }
    }
}