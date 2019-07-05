﻿using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.Google.Tests._Configuration.AutoMapper._Fixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoogleCreatorData = Google.Apis.Calendar.v3.Data.Event.CreatorData;

namespace Catharsium.Calendar.Google.Tests._Configuration.AutoMapper.MappingProfileTests
{
    [TestClass]
    public class CreatorMappingTests : MappingProfileFixture
    {
        [TestMethod]
        public void Map_CanMapEventReminder_ToReminder()
        {
            var creatorData = new GoogleCreatorData {
                DisplayName = "My display name",
                Email = "My email",
                Id = "My id",
                Self = true
            };

            var actual = this.Mapper.Map<Person>(creatorData);
            Assert.IsNotNull(actual);
            Assert.AreEqual(creatorData.DisplayName, actual.DisplayName);
            Assert.AreEqual(creatorData.Email, actual.Email);
            Assert.AreEqual(creatorData.Id, actual.Id);
            Assert.AreEqual(creatorData.Self, actual.Self);
        }
    }
}