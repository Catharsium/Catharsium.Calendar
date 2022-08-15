using Catharsium.Calendar.UI.Console.ActionHandlers;
using Catharsium.Calendar.UI.Console.Interfaces;
using Catharsium.External.GoogleCalendar.Client.Interfaces;
using Catharsium.External.GoogleCalendar.Client.Models;
using Catharsium.Util.IO.Console.Interfaces;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Threading.Tasks;

namespace Catharsium.Calendar.UI.Console.Tests.ActionHandlers;

[TestClass]
public class CreateEventActionHandlerTests : TestFixture<CreateEventActionHandler>
{
    #region Fixture

    private string Summary { get; set; }
    private DateTime StartDate { get; set; }
    private DateTime EndDate { get; set; }


    [TestInitialize]
    public void SetupProperties() {
        this.Summary = "My summary";
        this.StartDate = DateTime.Now;
        this.EndDate = DateTime.Now.AddHours(1);
    }


    #endregion

    [TestMethod]
    public async Task Run_ValidStartAndEndDate_CreatesEvent() {
        this.GetDependency<IConsole>().AskForText(Arg.Any<string>()).Returns(this.Summary);
        this.GetDependency<IConsole>().AskForDate(Arg.Is<string>(s => s.Contains("start date"))).Returns(this.StartDate);
        this.GetDependency<IConsole>().AskForDate(Arg.Is<string>(s => s.Contains("end date"))).Returns(this.EndDate);
        var calendar = new External.GoogleCalendar.Client.Models.Calendar { Id = "My calendar id" };
        this.GetDependency<IChooseCalendarStepHandler>().Run().Returns(calendar);

        await this.Target.Run();
        await this.GetDependency<IEventManagementService>().Received().CreateEvent(
            calendar.Id,
            Arg.Is<Event>(e => e.Summary == this.Summary &&
                               e.Start.Value == this.StartDate &&
                               e.End.Value == this.EndDate));
    }


    [TestMethod]
    public async Task Run_InvalidStartDate_DoesNotCreateEvent() {
        this.GetDependency<IConsole>().AskForText(Arg.Any<string>()).Returns(this.Summary);
        this.GetDependency<IConsole>().AskForDate(Arg.Is<string>(s => s.Contains("start date"))).Returns(null as DateTime?);
        this.GetDependency<IConsole>().AskForDate(Arg.Is<string>(s => s.Contains("end date"))).Returns(this.EndDate);
        var calendar = new External.GoogleCalendar.Client.Models.Calendar { Id = "My calendar id" };
        this.GetDependency<IChooseCalendarStepHandler>().Run().Returns(calendar);

        await this.Target.Run();
        await this.GetDependency<IEventManagementService>().DidNotReceive().CreateEvent(Arg.Any<string>(), Arg.Any<Event>());
    }


    [TestMethod]
    public async Task Run_InvalidEndDate_UsesStartDatePlus30Minutes() {
        this.GetDependency<IConsole>().AskForText(Arg.Any<string>()).Returns(this.Summary);
        this.GetDependency<IConsole>().AskForDate(Arg.Is<string>(s => s.Contains("start date"))).Returns(this.StartDate);
        this.GetDependency<IConsole>().AskForDate(Arg.Is<string>(s => s.Contains("end date"))).Returns(null as DateTime?);
        var calendar = new External.GoogleCalendar.Client.Models.Calendar { Id = "My calendar id" };
        this.GetDependency<IChooseCalendarStepHandler>().Run().Returns(calendar);

        await this.Target.Run();
        await this.GetDependency<IEventManagementService>().Received().CreateEvent(
            calendar.Id,
            Arg.Is<Event>(e => e.Summary == this.Summary &&
                               e.Start.Value == this.StartDate &&
                               e.End.Value == this.StartDate.AddMinutes(30)));
    }


    [TestMethod]
    public async Task Run_InvalidCalendar_DoesNotCreateEvent() {
        this.GetDependency<IConsole>().AskForText(Arg.Any<string>()).Returns(this.Summary);
        this.GetDependency<IConsole>().AskForDate(Arg.Is<string>(s => s.Contains("start date"))).Returns(this.StartDate);
        this.GetDependency<IConsole>().AskForDate(Arg.Is<string>(s => s.Contains("end date"))).Returns(this.EndDate);
        this.GetDependency<IChooseCalendarStepHandler>().Run().Returns(null as External.GoogleCalendar.Client.Models.Calendar);

        await this.Target.Run();
        await this.GetDependency<IEventManagementService>().DidNotReceive().CreateEvent(Arg.Any<string>(), Arg.Any<Event>());
    }
}