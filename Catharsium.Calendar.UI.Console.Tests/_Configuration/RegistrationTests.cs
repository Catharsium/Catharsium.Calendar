using Catharsium.Calendar.Core.Logic.Interfaces;
using Catharsium.Calendar.UI.Console._Configuration;
using Catharsium.Calendar.UI.Console.ActionHandlers;
using Catharsium.Calendar.UI.Console.Interfaces;
using Catharsium.Calendar.UI.Console.StepHandlers;
using Catharsium.Util.IO.Console.ActionHandlers.Interfaces;
using Catharsium.Util.IO.Console.Interfaces;
using Catharsium.Util.Testing.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
namespace Catharsium.Calendar.UI.Console.Tests._Configuration;

[TestClass]
public class RegistrationTests
{
    [TestMethod]
    public void AddGoogleCalendarConsoleUi_RegistersDependencies()
    {
        var serviceCollection = Substitute.For<IServiceCollection>();
        var configuration = Substitute.For<IConfiguration>();

        serviceCollection.AddGoogleCalendarConsoleUi(configuration);
        serviceCollection.ReceivedRegistration<IActionHandler, ImportActionHandler>();
        serviceCollection.ReceivedRegistration<IActionHandler, LoadActionHandler>();
        serviceCollection.ReceivedRegistration<IActionHandler, SearchActionHandler>();
        serviceCollection.ReceivedRegistration<IActionHandler, DeleteEventActionHandler>();
        serviceCollection.ReceivedRegistration<IActionHandler, CreateEventActionHandler>();
        serviceCollection.ReceivedRegistration<IActionHandler, MoveEventActionHandler>();
        serviceCollection.ReceivedRegistration<IActionHandler, ScheduleActionHandler>();
        serviceCollection.ReceivedRegistration<IActionHandler, TemplateSchedulerActionHandler>();

        serviceCollection.ReceivedRegistration<IShowEventsStepHandler, ShowEventsStepHandler>();
        serviceCollection.ReceivedRegistration<IChooseCalendarStepHandler, ChooseCalendarStepHandler>();
        serviceCollection.ReceivedRegistration<IChooseEventStepHandler, ChooseEventStepHandler>();
        serviceCollection.ReceivedRegistration<IChooseAccountStepHandler, ChooseAccountStepHandler>();
    }


    [TestMethod]
    public void AddGoogleCalendarConsoleUi_RegistersPackages()
    {
        var serviceCollection = Substitute.For<IServiceCollection>();
        var configuration = Substitute.For<IConfiguration>();

        serviceCollection.AddGoogleCalendarConsoleUi(configuration);
        serviceCollection.ReceivedRegistration<ICalendarImporter>();
        serviceCollection.ReceivedRegistration<IConsole>();
    }
}