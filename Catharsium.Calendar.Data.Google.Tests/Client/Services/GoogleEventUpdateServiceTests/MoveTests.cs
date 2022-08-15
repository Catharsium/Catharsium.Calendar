using Catharsium.Clients.GoogleCalendar.Client.Services;
using Catharsium.Clients.GoogleCalendar.Interfaces;
using Catharsium.Clients.GoogleCalendar.Models;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Threading.Tasks;

namespace Catharsium.Clients.GoogleCalendar.Tests.Client.Services.GoogleEventUpdateServiceTests;

[TestClass]
public class MoveTests : TestFixture<GoogleEventUpdateService>
{
    #region Fixture

    private Event Event { get; set; }


    [TestInitialize]
    public void SetupProperties()
    {
        this.Event = new Event {
            Id = "My event id",
            ICalUID = "My cal uid"
        };
    }

    #endregion

    [TestMethod]
    public async Task Move_CreatesEventOnNewCalendar_Successful_DeletesFromOld()
    {
        var oldCalendarId = "My old calendar id";
        var newCalendarId = "My new calendar id";
        var expected = new Event();
        this.GetDependency<IEventManagementService>().CreateEvent(newCalendarId, this.Event).Returns(expected);

        var actual = await this.Target.Move(this.Event, oldCalendarId, newCalendarId);
        Assert.AreEqual(expected, actual);
        await this.GetDependency<IEventManagementService>().Received().DeleteEvent(oldCalendarId, this.Event.Id);
    }


    [TestMethod]
    public async Task Move_CreatesEventOnNewCalendar_NotSuccessful_DoesNotDeleteFromOld()
    {
        var oldCalendarId = "My old calendar id";
        var newCalendarId = "My new calendar id";
        this.GetDependency<IEventManagementService>().CreateEvent(newCalendarId, this.Event).Returns(null as Event);

        var actual = await this.Target.Move(this.Event, oldCalendarId, newCalendarId);
        Assert.IsNull(actual);
        await this.GetDependency<IEventManagementService>().Received().DeleteEvent(oldCalendarId, this.Event.Id);
    }
}