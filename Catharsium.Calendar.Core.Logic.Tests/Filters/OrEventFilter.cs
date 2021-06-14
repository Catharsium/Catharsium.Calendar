using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.Core.Logic.Filters;
using Catharsium.Util.Filters;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Collections.Generic;

namespace Catharsium.Calendar.Core.Logic.Tests.Filters
{
    [TestClass]
    public class OrFilterTests : TestFixture<OrEventFilter>
    {
        #region Fixture

        private IFilter<Event> FirstFilter { get; set; }
        private IFilter<Event> SecondFilter { get; set; }


        [TestInitialize]
        public void SetupDependencies()
        {
            this.FirstFilter = Substitute.For<IFilter<Event>>();
            this.SecondFilter = Substitute.For<IFilter<Event>>();
        }

        #endregion

        #region Includes

        [TestMethod]
        public void Includes_AllFiltersSucceed_ReturnsTrue()
        {
            var @event = new Event();
            this.FirstFilter.Includes(Arg.Any<Event>()).Returns(true);
            this.SecondFilter.Includes(Arg.Any<Event>()).Returns(true);
            this.Target.Filters = new List<IFilter<Event>> { this.FirstFilter, this.SecondFilter };

            var actual = this.Target.Includes(@event);
            Assert.IsTrue(actual);
        }


        [TestMethod]
        public void Includes_SingleFiltersSucceeds_ReturnsTrue()
        {
            var @event = new Event();
            this.FirstFilter.Includes(Arg.Any<Event>()).Returns(true);
            this.SecondFilter.Includes(Arg.Any<Event>()).Returns(false);
            this.Target.Filters = new List<IFilter<Event>> { this.FirstFilter, this.SecondFilter };

            var actual = this.Target.Includes(@event);
            Assert.IsTrue(actual);
        }


        [TestMethod]
        public void Includes_AllFiltersFail_ReturnsFalse()
        {
            var @event = new Event();
            this.FirstFilter.Includes(Arg.Any<Event>()).Returns(false);
            this.SecondFilter.Includes(Arg.Any<Event>()).Returns(false);
            this.Target.Filters = new List<IFilter<Event>> { this.FirstFilter, this.SecondFilter };

            var actual = this.Target.Includes(@event);
            Assert.IsFalse(actual);
        }

        #endregion
    }
}