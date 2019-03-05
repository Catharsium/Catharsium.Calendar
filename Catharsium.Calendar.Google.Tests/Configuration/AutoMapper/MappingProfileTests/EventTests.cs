﻿using System;
using Catharsium.Calendar.Core.Entities.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoogleEvent = Google.Apis.Calendar.v3.Data.Event;
using GoogleEventDateTime = Google.Apis.Calendar.v3.Data.EventDateTime;

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
            Assert.IsTrue(actual.End.HasTime);
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
            Assert.IsFalse(actual.Start.HasTime);
            Assert.AreEqual(calendar.Start.Date, actual.Start.Value.ToString("yyyy-MM-dd"));
            Assert.IsFalse(actual.End.HasTime);
            Assert.AreEqual(calendar.End.Date, actual.End.Value.ToString("yyyy-MM-dd"));
        }
    }
}