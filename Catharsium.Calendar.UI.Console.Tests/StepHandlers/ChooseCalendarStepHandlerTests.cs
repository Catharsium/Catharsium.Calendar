using Catharsium.Calendar.UI.Console.StepHandlers;
using Catharsium.Clients.GoogleCalendar.Interfaces;
using Catharsium.Util.IO.Console.Interfaces;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Threading.Tasks;

namespace Catharsium.Calendar.UI.Console.Tests.StepHandlers;

[TestClass]
public class ChooseCalendarStepHandlerTests : TestFixture<ChooseCalendarStepHandler>
{
    [TestMethod]
    public async Task Run_WritesCalendars()
    {
        var index = 1;
        this.GetDependency<IConsole>().AskForInt().Returns(index);
        var calendars = new[] {
        new Clients.GoogleCalendar.Models.Calendar {Summary = "My first calendar"},
        new Clients.GoogleCalendar.Models.Calendar {Summary = "My second calendar"}
    };
        this.GetDependency<IGoogleCalendarService>().GetList().Returns(calendars);

        await this.Target.Run();
        foreach(var calendar in calendars) {
            this.GetDependency<IConsole>().Received().WriteLine(Arg.Is<string>(s => s.Contains(calendar.Summary)));
        }
    }


    [TestMethod]
    public async Task Run_ValidCalendarIndex_ReturnsCalendar()
    {
        var index = 1;
        this.GetDependency<IConsole>().AskForInt().Returns(index);
        var calendars = new[] {
        new Clients.GoogleCalendar.Models.Calendar {Summary = "My first calendar"},
        new Clients.GoogleCalendar.Models.Calendar {Summary = "My second calendar"}
    };
        this.GetDependency<IGoogleCalendarService>().GetList().Returns(calendars);

        var actual = await this.Target.Run();
        Assert.AreEqual(calendars[index - 1], actual);
    }


    [TestMethod]
    public async Task Run_NoCalendarIndex_ReturnsCalendar()
    {
        this.GetDependency<IConsole>().AskForInt().Returns(null as int?);
        var calendars = new[] {
        new Clients.GoogleCalendar.Models.Calendar {Summary = "My first calendar"},
        new Clients.GoogleCalendar.Models.Calendar {Summary = "My second calendar"}
    };
        this.GetDependency<IGoogleCalendarService>().GetList().Returns(calendars);

        var actual = await this.Target.Run();
        Assert.IsNull(actual);
    }
}