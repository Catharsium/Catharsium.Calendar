using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.Google.Tests._Configuration.AutoMapper._Fixture;
using Google.Apis.Calendar.v3.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Event = Google.Apis.Calendar.v3.Data.Event;

namespace Catharsium.Calendar.Google.Tests._Configuration.AutoMapper.MappingProfileTests
{
    [TestClass]
    public class RemindersListMappingTests : MappingProfileFixture
    {
        [TestMethod]
        public void Map_CanMapEventReminder_ToReminder()
        {
            var remindersData = new Event.RemindersData {
                Overrides = new List<EventReminder> {
                    new EventReminder()
                },
                UseDefault = true
            };

            var actual = this.Mapper.Map<RemindersList>(remindersData);
            Assert.IsNotNull(actual);
            Assert.AreEqual(remindersData.Overrides.Count, actual.Overrides.Count);
            Assert.AreEqual(remindersData.UseDefault, actual.UseDefault);
        }
    }
}