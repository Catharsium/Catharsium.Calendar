using Catharsium.Calendar.Core.Logic.Filters;
using Catharsium.External.GoogleCalendar.Client.Models;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Catharsium.Calendar.Core.Logic.Tests.Filters;

[TestClass]
public class StartDateEventFilterTests : TestFixture<StartDateEventFilter>
{
    #region Fixture

    private DateTime FromDate { get; set; }
    private DateTime ToDate { get; set; }


    [TestInitialize]
    public void SetupProperties() {
        this.FromDate = DateTime.Now.AddDays(-1);
        this.ToDate = DateTime.Now.AddDays(1);
        this.Target.From = this.FromDate;
        this.Target.To = this.ToDate;
    }

    #endregion

    #region Includes_WithoutTime

    [TestMethod]
    public void Includes_WithoutTime_EventBeforeFromDate_ReturnsFalse() {
        var @event = new Event {
            Id = "My id",
            Start = new Date {
                Value = this.FromDate.AddDays(-1),
                HasTime = false
            }
        };

        var actual = this.Target.Includes(@event);
        Assert.IsFalse(actual);
    }


    [TestMethod]
    public void Includes_WithoutTime_EventOnFromDate_ReturnsTrue() {
        var @event = new Event {
            Id = "My id",
            Start = new Date {
                Value = this.FromDate,
                HasTime = false
            }
        };

        var actual = this.Target.Includes(@event);
        Assert.IsTrue(actual);
    }


    [TestMethod]
    public void Includes_WithoutTime_EventBetweenFromAndToDate_ReturnsTrue() {
        var @event = new Event {
            Id = "My id",
            Start = new Date {
                Value = this.FromDate.AddDays(1),
                HasTime = false
            }
        };

        var actual = this.Target.Includes(@event);
        Assert.IsTrue(actual);
    }


    [TestMethod]
    public void Includes_WithoutTime_EventOnToDate_ReturnsTrue() {
        var @event = new Event {
            Id = "My id",
            Start = new Date {
                Value = this.ToDate,
                HasTime = false
            }
        };

        var actual = this.Target.Includes(@event);
        Assert.IsTrue(actual);
    }


    [TestMethod]
    public void Includes_WithoutTime_EventAfterToDate_ReturnsFalse() {
        var @event = new Event {
            Id = "My id",
            Start = new Date {
                Value = this.ToDate.AddDays(1),
                HasTime = false
            }
        };

        var actual = this.Target.Includes(@event);
        Assert.IsFalse(actual);
    }

    #endregion

    #region Includes_WithTime

    [TestMethod]
    public void Includes_WithTime_EventBeforeFromDate_ReturnsFalse() {
        var @event = new Event {
            Id = "My id",
            Start = new Date {
                Value = this.FromDate.AddDays(-1),
                HasTime = true
            }
        };

        var actual = this.Target.Includes(@event);
        Assert.IsFalse(actual);
    }


    [TestMethod]
    public void Includes_WithTime_EventOnFromDate_ReturnsTrue() {
        var @event = new Event {
            Id = "My id",
            Start = new Date {
                Value = this.FromDate,
                HasTime = true
            }
        };

        var actual = this.Target.Includes(@event);
        Assert.IsTrue(actual);
    }


    [TestMethod]
    public void Includes_WithTime_EventBetweenFromAndToDate_ReturnsTrue() {
        var @event = new Event {
            Id = "My id",
            Start = new Date {
                Value = this.FromDate.AddDays(1),
                HasTime = true
            }
        };

        var actual = this.Target.Includes(@event);
        Assert.IsTrue(actual);
    }


    [TestMethod]
    public void Includes_WithTime_EventOnToDate_ReturnsTrue() {
        var @event = new Event {
            Id = "My id",
            Start = new Date {
                Value = this.ToDate,
                HasTime = true
            }
        };

        var actual = this.Target.Includes(@event);
        Assert.IsTrue(actual);
    }


    [TestMethod]
    public void Includes_WithTime_EventAfterToDate_ReturnsFalse() {
        var @event = new Event {
            Id = "My id",
            Start = new Date {
                Value = this.ToDate.AddDays(1),
                HasTime = true
            }
        };

        var actual = this.Target.Includes(@event);
        Assert.IsFalse(actual);
    }

    #endregion
}