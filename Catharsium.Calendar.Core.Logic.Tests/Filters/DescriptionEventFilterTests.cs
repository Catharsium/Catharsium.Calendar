using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.Core.Logic.Filters;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Calendar.Core.Logic.Tests.Filters
{
    [TestClass]
    public class DescriptionEventFilterTests : TestFixture<DescriptionEventFilter>
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
        public void Includes_DescriptionContainsQuery_ReturnsTrue()
        {
            this.SetDependency(true, "ignoreCase");
            var @event = new Event {
                Description = "My description " + this.Query.ToLower()
            };

            var actual = this.Target.Includes(@event);
            Assert.IsTrue(actual);
        }


        [TestMethod]
        public void Includes_DescriptionWithoutQuery_ReturnsFalse()
        {
            this.SetDependency(true, "ignoreCase");
            var @event = new Event {
                Description = this.Query.Substring(1)
            };

            var actual = this.Target.Includes(@event);
            Assert.IsFalse(actual);
        }


        [TestMethod]
        public void Includes_IgnoreCase_DescriptionContainsQuery_ReturnsTrue()
        {
            this.SetDependency(false, "ignoreCase");
            var @event = new Event {
                Description = "My description " + this.Query
            };

            var actual = this.Target.Includes(@event);
            Assert.IsTrue(actual);
        }


        [TestMethod]
        public void Includes_IgnoreCase_DescriptionWithUpperCaseQuery_ReturnsFalse()
        {
            this.SetDependency(false, "ignoreCase");
            var @event = new Event {
                Description = "My description " + this.Query.ToUpper()
            };

            var actual = this.Target.Includes(@event);
            Assert.IsFalse(actual);
        }


        [TestMethod]
        public void Includes_IgnoreCase_DescriptionWithoutQuery_ReturnsFalse()
        {
            this.SetDependency(false, "ignoreCase");
            var @event = new Event {
                Description = this.Query.ToLower().Substring(1)
            };

            var actual = this.Target.Includes(@event);
            Assert.IsFalse(actual);
        }
    }
}