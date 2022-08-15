using Catharsium.Calendar.Core.Logic.Filters;
using Catharsium.Clients.GoogleCalendar.Models;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Calendar.Core.Logic.Tests.Filters;

[TestClass]
public class LocationEventFilterTests : TestFixture<LocationEventFilter>
{
    #region Fixture

    private string Query { get; } = "My Query";


    [TestInitialize]
    public void SetupProperties()
    {
        this.Target.Query = this.Query;
    }

    #endregion

    [TestMethod]
    public void Includes_LocationContainsQuery_ReturnsTrue()
    {
        this.Target.IgnoreCase = true;
        var @event = new Event {
            Location = "My location " + this.Query.ToLower()
        };

        var actual = this.Target.Includes(@event);
        Assert.IsTrue(actual);
    }


    [TestMethod]
    public void Includes_LocationWithoutQuery_ReturnsFalse()
    {
        this.Target.IgnoreCase = true;
        var @event = new Event {
            Location = this.Query[1..]
        };

        var actual = this.Target.Includes(@event);
        Assert.IsFalse(actual);
    }


    [TestMethod]
    public void Includes_IgnoreCase_LocationContainsQuery_ReturnsTrue()
    {
        this.Target.IgnoreCase = false;
        var @event = new Event {
            Location = "My location " + this.Query
        };

        var actual = this.Target.Includes(@event);
        Assert.IsTrue(actual);
    }


    [TestMethod]
    public void Includes_IgnoreCase_LocationWithUpperCaseQuery_ReturnsFalse()
    {
        this.Target.IgnoreCase = false;
        var @event = new Event {
            Location = "My location " + this.Query.ToUpper()
        };

        var actual = this.Target.Includes(@event);
        Assert.IsFalse(actual);
    }


    [TestMethod]
    public void Includes_IgnoreCase_LocationWithoutQuery_ReturnsFalse()
    {
        this.Target.IgnoreCase = false;
        var @event = new Event {
            Location = this.Query.ToLower()[1..]
        };

        var actual = this.Target.Includes(@event);
        Assert.IsFalse(actual);
    }
}