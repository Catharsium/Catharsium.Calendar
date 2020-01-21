using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.Core.Logic.Filters;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Calendar.Core.Logic.Tests.Filters
{
    [TestClass]
    public class SummaryEventFilterTests : TestFixture<SummaryEventFilter>
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
        public void Includes_SummaryContainsQuery_ReturnsTrue()
        {
            this.SetDependency(true, "ignoreCase");
            var @event = new Event {
                Summary = "My summary " + this.Query.ToLower()
            };

            var actual = this.Target.Includes(@event);
            Assert.IsTrue(actual);
        }


        [TestMethod]
        public void Includes_SummaryWithoutQuery_ReturnsFalse()
        {
            this.SetDependency(true, "ignoreCase");
            var @event = new Event {
                Summary = this.Query.Substring(1)
            };

            var actual = this.Target.Includes(@event);
            Assert.IsFalse(actual);
        }


        [TestMethod]
        public void Includes_IgnoreCase_SummaryContainsQuery_ReturnsTrue()
        {
            this.SetDependency(false, "ignoreCase");
            var @event = new Event {
                Summary = "My summary " + this.Query
            };

            var actual = this.Target.Includes(@event);
            Assert.IsTrue(actual);
        }


        [TestMethod]
        public void Includes_IgnoreCase_SummaryWithUpperCaseQuery_ReturnsFalse()
        {
            this.SetDependency(false, "ignoreCase");
            var @event = new Event {
                Summary = "My summary " + this.Query.ToUpper()
            };

            var actual = this.Target.Includes(@event);
            Assert.IsFalse(actual);
        }


        [TestMethod]
        public void Includes_IgnoreCase_SummaryWithoutQuery_ReturnsFalse()
        {
            this.SetDependency(false, "ignoreCase");
            var @event = new Event {
                Summary = this.Query.ToLower().Substring(1)
            };

            var actual = this.Target.Includes(@event);
            Assert.IsFalse(actual);
        }
    }
}