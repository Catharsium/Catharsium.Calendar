using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.Core.Logic.Filters;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Calendar.Core.Logic.Tests.Filters
{
    [TestClass]
    public class LocationEventFilterTests : TestFixture<LocationEventFilter>
    {
        #region Fixture

        private string Query { get; } = "My Query";


        [TestInitialize]
        public void SetupProperties()
        {
            this.SetDependency(this.Query, "query");
        }

        #endregion

        [TestMethod]
        public void Includes_LocationContainsQuery_ReturnsTrue()
        {
            this.SetDependency(true, "ignoreCase");
            var @event = new Event {
                Location = "My location " + this.Query.ToLower()
            };

            var actual = this.Target.Includes(@event);
            Assert.IsTrue(actual);
        }


        [TestMethod]
        public void Includes_LocationWithoutQuery_ReturnsFalse()
        {
            this.SetDependency(true, "ignoreCase");
            var @event = new Event {
                Location = this.Query.Substring(1)
            };

            var actual = this.Target.Includes(@event);
            Assert.IsFalse(actual);
        }


        [TestMethod]
        public void Includes_IgnoreCase_LocationContainsQuery_ReturnsTrue()
        {
            this.SetDependency(false, "ignoreCase");
            var @event = new Event {
                Location = "My location " + this.Query
            };

            var actual = this.Target.Includes(@event);
            Assert.IsTrue(actual);
        }


        [TestMethod]
        public void Includes_IgnoreCase_LocationWithUpperCaseQuery_ReturnsFalse()
        {
            this.SetDependency(false, "ignoreCase");
            var @event = new Event {
                Location = "My location " + this.Query.ToUpper()
            };

            var actual = this.Target.Includes(@event);
            Assert.IsFalse(actual);
        }


        [TestMethod]
        public void Includes_IgnoreCase_LocationWithoutQuery_ReturnsFalse()
        {
            this.SetDependency(false, "ignoreCase");
            var @event = new Event {
                Location = this.Query.ToLower().Substring(1)
            };

            var actual = this.Target.Includes(@event);
            Assert.IsFalse(actual);
        }
    }
}