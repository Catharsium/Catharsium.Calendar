using Catharsium.Calendar.Google.Tests._Configuration.AutoMapper._Fixture;
using Google.Apis.Calendar.v3.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Event = Catharsium.Calendar.Core.Entities.Models.Event;
using GoogleEvent = Google.Apis.Calendar.v3.Data.Event;
using GoogleEventDateTime = Google.Apis.Calendar.v3.Data.EventDateTime;

namespace Catharsium.Calendar.Google.Tests._Configuration.AutoMapper.GoogleToLocalMappingProfileTests
{
    [TestClass]
    public class ToLocalEventMappingTests : GoogleToLocalMappingProfileFixture
    {
        [TestMethod]
        public void Map_CanMapEvent_ToEvent()
        {
            var calendar = new GoogleEvent
            {
                Id = "My id"
            };

            var actual = this.Mapper.Map<Event>(calendar);
            Assert.IsNotNull(actual);
            Assert.AreEqual(calendar.Id, actual.Id);
        }


        [TestMethod]
        public void Map_CanMapGoogleEventDateTime_ToDateTime()
        {
            var calendar = new GoogleEvent
            {
                Start = new GoogleEventDateTime { DateTime = DateTime.Now, },
                End = new GoogleEventDateTime { DateTime = DateTime.Now }
            };

            var actual = this.Mapper.Map<Event>(calendar);
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Start.HasTime);
            Assert.AreEqual(calendar.Start.DateTime.Value, actual.Start.Value);
            Assert.IsTrue(actual.Start.HasTime);
            Assert.AreEqual(calendar.End.DateTime.Value, actual.End.Value);
        }


        [TestMethod]
        public void Map_CanMapGoogleEventDateOnly_ToDateWithoutTime()
        {
            var calendar = new GoogleEvent
            {
                Start = new GoogleEventDateTime { Date = DateTime.Now.ToString("yyyy-MM-dd") },
                End = new GoogleEventDateTime { Date = DateTime.Now.ToString("yyyy-MM-dd") }
            };

            var actual = this.Mapper.Map<Event>(calendar);
            Assert.IsNotNull(actual);
            Assert.AreEqual(calendar.Start.Date, actual.Start.Value.ToString("yyyy-MM-dd"));
            Assert.IsFalse(actual.Start.HasTime);
            Assert.AreEqual(calendar.End.Date, actual.End.Value.ToString("yyyy-MM-dd"));
            Assert.IsFalse(actual.Start.HasTime);
        }


        [TestMethod]
        public void Map_CanMapGoogleEventWithOriginalStartTime_ToEvent()
        {
            var calendar = new GoogleEvent
            {
                OriginalStartTime = new GoogleEventDateTime { DateTime = DateTime.Now }
            };

            var actual = this.Mapper.Map<Event>(calendar);
            Assert.IsNotNull(actual);
            Assert.AreEqual(calendar.OriginalStartTime.DateTime, actual.OriginalStartTime.Value);
        }


        [TestMethod]
        public void Map_CanMapGoogleEventWithReminders_ToEvent()
        {
            var calendar = new GoogleEvent
            {
                Reminders = new GoogleEvent.RemindersData
                {
                    Overrides = new List<EventReminder> {
                        new EventReminder()
                    },
                    UseDefault = true
                }
            };

            var actual = this.Mapper.Map<Event>(calendar);
            Assert.IsNotNull(actual);
            Assert.IsNotNull(actual.RemindersList);
        }


        [TestMethod]
        public void Map_CanMapGoogleEventWithCreator_ToEvent()
        {
            var calendar = new GoogleEvent
            {
                Creator = new GoogleEvent.CreatorData()
            };

            var actual = this.Mapper.Map<Event>(calendar);
            Assert.IsNotNull(actual);
            Assert.IsNotNull(actual.Creator);
        }
    }
}