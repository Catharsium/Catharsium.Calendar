using System;
using System.Collections.Generic;
using System.Linq;
using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.Core.Logic.Filters;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Calendar.Core.Logic.Tests.Filters.DateEventFilterTests
{
    [TestClass]
    public class ApplyToStartDateTests : TestFixture<DateEventFilter>
    {
        #region Fixture

        private List<Event> DateOnlyEvents { get; set; }


        [TestInitialize]
        public void SetupProperties()
        {
            this.DateOnlyEvents = new List<Event> {
                new Event {
                    Id = "1",
                    Start = new Date {
                        Value = DateTime.Now.AddDays(-1),
                        HasTime = true
                    }
                },
                new Event {
                    Id = "2",
                    Start = new Date {
                        Value = DateTime.Now.Date,
                        HasTime = false
                    }
                },
                new Event {
                    Id = "3",
                    Start = new Date {
                        Value = DateTime.Now.AddDays(1),
                        HasTime = true
                    }
                }
            };
        }

        #endregion

        [TestMethod]
        public void ApplyToStartDate_FindsEventsWithStartDateWithinScope()
        {
            var actual = this.Target.ApplyToStartDate(this.DateOnlyEvents, this.DateOnlyEvents[0].Start.Value, DateTime.MaxValue).ToList();
            Assert.AreEqual(3, actual.Count);
            Assert.IsTrue(actual.Contains(this.DateOnlyEvents[0]));
            Assert.IsTrue(actual.Contains(this.DateOnlyEvents[1]));
            Assert.IsTrue(actual.Contains(this.DateOnlyEvents[2]));
        }


        [TestMethod]
        public void ApplyToStartDate_DoesNotIncludeEarlierEvents()
        {
            var actual = this.Target.ApplyToStartDate(this.DateOnlyEvents, this.DateOnlyEvents[1].Start.Value, DateTime.MaxValue).ToList();
            Assert.AreEqual(2, actual.Count);
            Assert.IsTrue(actual.Contains(this.DateOnlyEvents[1]));
            Assert.IsTrue(actual.Contains(this.DateOnlyEvents[2]));
        }


        [TestMethod]
        public void ApplyToStartDate_DoesNotIncludeLaterEvents()
        {
            var actual = this.Target.ApplyToStartDate(this.DateOnlyEvents, DateTime.MinValue, this.DateOnlyEvents[1].Start.Value).ToList();
            Assert.AreEqual(2, actual.Count);
            Assert.IsTrue(actual.Contains(this.DateOnlyEvents[0]));
            Assert.IsTrue(actual.Contains(this.DateOnlyEvents[1]));
        }


        [TestMethod]
        public void ApplyToStartDate_IsFromInclusive()
        {
            var actual = this.Target.ApplyToStartDate(this.DateOnlyEvents, this.DateOnlyEvents[2].Start.Value, DateTime.MaxValue).ToList();
            Assert.AreEqual(1, actual.Count);
            Assert.IsTrue(actual.Contains(this.DateOnlyEvents[2]));
        }


        [TestMethod]
        public void ApplyToStartDate_IsUntilInclusive()
        {
            var actual = this.Target.ApplyToStartDate(this.DateOnlyEvents, DateTime.MinValue, this.DateOnlyEvents[0].Start.Value).ToList();
            Assert.AreEqual(1, actual.Count);
            Assert.IsTrue(actual.Contains(this.DateOnlyEvents[0]));
        }


        [TestMethod]
        public void ApplyToStartDate_ConsidersUntilHasTime()
        {
            var actual = this.Target.ApplyToStartDate(this.DateOnlyEvents, DateTime.MinValue, this.DateOnlyEvents[2].Start.Value.Date).ToList();
            Assert.AreEqual(2, actual.Count);
            Assert.IsTrue(actual.Contains(this.DateOnlyEvents[0]));
            Assert.IsTrue(actual.Contains(this.DateOnlyEvents[1]));
        }
    }
}