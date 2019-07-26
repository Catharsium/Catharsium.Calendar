using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.Google.Tests._Configuration.AutoMapper._Fixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using GoogleRemindersList = Google.Apis.Calendar.v3.Data.Event.RemindersData;

namespace Catharsium.Calendar.Google.Tests._Configuration.AutoMapper.GoogleToLocalMappingProfileTests
{
    [TestClass]
    public class ToGoogleRemindersListMappingTests : LocalToGoogleMappingProfileFixture
    {
        [TestMethod]
        public void Map_CanMapRemindersList_ToRemindersData()
        {
            var remindersData = new RemindersList
            {
                Overrides = new List<Reminder> {
                    new Reminder()
                },
                UseDefault = true
            };

            var actual = this.Mapper.Map<GoogleRemindersList>(remindersData);
            Assert.IsNotNull(actual);
            Assert.AreEqual(remindersData.Overrides.Count, actual.Overrides.Count);
            Assert.AreEqual(remindersData.UseDefault, actual.UseDefault);
        }
    }
}