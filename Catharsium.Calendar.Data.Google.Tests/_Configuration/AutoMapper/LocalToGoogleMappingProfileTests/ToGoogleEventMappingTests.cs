using Catharsium.Clients.GoogleCalendar.Models;
using Catharsium.Clients.GoogleCalendar.Tests._Configuration.AutoMapper._Fixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Date = Catharsium.Clients.GoogleCalendar.Models.Date;
using Event = Catharsium.Clients.GoogleCalendar.Models.Event;
using GoogleEvent = Google.Apis.Calendar.v3.Data.Event;

namespace Catharsium.Clients.GoogleCalendar.Tests._Configuration.AutoMapper.LocalToGoogleMappingProfileTests;

[TestClass]
public class ToGoogleEventMappingTests : LocalToGoogleMappingProfileFixture
{
    [TestMethod]
    public void Map_CanMapEvent_ToEvent()
    {
        var calendar = new Event {
            Id = "My id"
        };

        var actual = this.Mapper.Map<GoogleEvent>(calendar);
        Assert.IsNotNull(actual);
        Assert.AreEqual(calendar.Id, actual.Id);
    }


    [TestMethod]
    public void Map_CanMapEventWithDatesAndTime_ToEvent()
    {
        var calendar = new Event {
            Start = new Date {
                Value = DateTime.Now,
                HasTime = true
            },
            End = new Date {
                Value = DateTime.Now,
                HasTime = true
            }
        };

        var actual = this.Mapper.Map<GoogleEvent>(calendar);
        Assert.IsNotNull(actual);
        Assert.IsTrue(actual.Start.DateTime.HasValue);
        Assert.AreEqual(calendar.Start.Value.Date, actual.Start.DateTime.Value.Date);
        Assert.AreEqual(calendar.Start.Value.Hour, actual.Start.DateTime.Value.Hour);
        Assert.AreEqual(calendar.Start.Value.Minute, actual.Start.DateTime.Value.Minute);
        Assert.AreEqual(calendar.Start.Value.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ"), actual.Start.DateTimeRaw);
        Assert.IsTrue(actual.End.DateTime.HasValue);
        Assert.AreEqual(calendar.End.Value.Date, actual.End.DateTime.Value.Date);
        Assert.AreEqual(calendar.End.Value.Hour, actual.End.DateTime.Value.Hour);
        Assert.AreEqual(calendar.End.Value.Minute, actual.End.DateTime.Value.Minute);
        Assert.AreEqual(calendar.End.Value.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ"), actual.End.DateTimeRaw);
    }


    [TestMethod]
    public void Map_CanMapEventWithOriginalStartTime_ToEvent()
    {
        var calendar = new Event {
            OriginalStartTime = new Date { Value = DateTime.Now }
        };

        var actual = this.Mapper.Map<GoogleEvent>(calendar);
        Assert.IsNotNull(actual);
        Assert.AreEqual(calendar.OriginalStartTime.Value.Date, actual.OriginalStartTime.DateTime.Value.Date);
        Assert.AreEqual(calendar.OriginalStartTime.Value.Hour, actual.OriginalStartTime.DateTime.Value.Hour);
        Assert.AreEqual(calendar.OriginalStartTime.Value.Minute, actual.OriginalStartTime.DateTime.Value.Minute);
    }


    [TestMethod]
    public void Map_CanMapEventWithReminders_ToEvent()
    {
        var @event = new Event {
            RemindersList = new RemindersList {
                Overrides = new List<Reminder> {
                    new Reminder()
                },
                UseDefault = true
            }
        };

        var actual = this.Mapper.Map<GoogleEvent>(@event);
        Assert.IsNotNull(actual);
        Assert.IsNotNull(actual.Reminders);
    }


    [TestMethod]
    public void Map_CanMapEventWithCreator_ToEvent()
    {
        var @event = new Event {
            Creator = new Person()
        };

        var actual = this.Mapper.Map<Event>(@event);
        Assert.IsNotNull(actual);
        Assert.IsNotNull(actual.Creator);
    }
}