using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.Core.Logic.Filters;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Catharsium.Calendar.Core.Logic.Tests.Filters.TextEventFilterTests
{
    [TestClass]
    public class ApplyToLocationTests : TestFixture<TextEventFilter>
    {
        #region Fixture

        private List<Event> Events { get; set; }


        [TestInitialize]
        public void SetupProperties()
        {
            this.Events = new List<Event> {
                new Event {
                    Id = "1",
                    Summary = "My first summary",
                    Description = "My first description",
                    Location = "My first location"
                },
                new Event {
                    Id = "2",
                    Summary = "My second summary",
                    Description = "My second description",
                    Location = "My second location"
                },
                new Event {
                    Id = "3",
                    Summary = "My third summary",
                    Description = "My third description",
                    Location = "My third location"
                }
            };
        }

        #endregion

        [TestMethod]
        public void ApplyToLocation_FindsEventWithTextInLocation()
        {
            var expectedEvent = this.Events[0];
            var actual = this.Target.ApplyToLocation(this.Events, expectedEvent.Location).ToList();
            Assert.AreEqual(1, actual.Count);
            Assert.IsTrue(actual.Contains(expectedEvent));
        }


        [TestMethod]
        public void ApplyToLocation_EmptyText_ReturnsAll()
        {
            var actual = this.Target.ApplyToLocation(this.Events, "").ToList();
            Assert.AreEqual(this.Events.Count, actual.Count);
        }
    }
}