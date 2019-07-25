using Catharsium.Calendar.Core.Logic.Interfaces;
using Catharsium.Calendar.UI.Console._Configuration;
using Catharsium.Calendar.UI.Console.ActionHandlers;
using Catharsium.Calendar.UI.Console.Interfaces;
using Catharsium.Calendar.UI.Console.StepHandlers;
using Catharsium.Util.Testing.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Calendar.UI.Console.Tests._Configuration
{
    [TestClass]
    public class CalendarGoogleUiRegistrationTests
    {
        [TestMethod]
        public void AddGoogleCalendarConsoleUi_RegistersDependencies()
        {
            var serviceCollection = Substitute.For<IServiceCollection>();
            var configuration = Substitute.For<IConfiguration>();

            serviceCollection.AddGoogleCalendarConsoleUi(configuration);
            serviceCollection.ReceivedRegistration<IImportActionHandler, ImportActionHandler>();
            serviceCollection.ReceivedRegistration<ILoadActionHandler, LoadActionHandler>();
            serviceCollection.ReceivedRegistration<ISearchActionHandler, SearchActionHandler>();
            serviceCollection.ReceivedRegistration<IShowEventsStepHandler, ShowEventsStepHandler>();
            serviceCollection.ReceivedRegistration<IChooseACalendarStepHandler, ChooseACalendarStepHandler>();
        }


        [TestMethod]
        public void AddGoogleCalendarConsoleUi_RegistersPackages()
        {
            var serviceCollection = Substitute.For<IServiceCollection>();
            var configuration = Substitute.For<IConfiguration>();

            serviceCollection.AddGoogleCalendarConsoleUi(configuration);
            serviceCollection.ReceivedRegistration<ICalendarStorage>();
            serviceCollection.ReceivedRegistration<ICalendarImporter>();
        }
    }
}