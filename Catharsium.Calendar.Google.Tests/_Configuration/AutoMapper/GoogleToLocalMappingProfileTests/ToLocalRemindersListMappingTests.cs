using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.Google.Tests._Configuration.AutoMapper._Fixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using GoogleReminder = Google.Apis.Calendar.v3.Data.EventReminder;
using GoogleRemindersList = Google.Apis.Calendar.v3.Data.Event.RemindersData;

namespace Catharsium.Calendar.Google.Tests._Configuration.AutoMapper.GoogleToLocalMappingProfileTests
{
    [TestClass]
    public class ToLocalRemindersListMappingTests : GoogleToLocalMappingProfileFixture
    {
        [TestMethod]
        public void Map_CanMapEventReminder_ToReminder()
        {
            var remindersData = new GoogleRemindersList
            {
                Overrides = new List<GoogleReminder> {
                    new GoogleReminder()
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