using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.Core.Entities.Models.Comparers;
using Catharsium.Calendar.Core.Logic._Configuration;
using Catharsium.Calendar.Core.Logic.Filters;
using Catharsium.Calendar.Core.Logic.Interfaces;
using Catharsium.Calendar.Core.Logic.Presentation;
using Catharsium.Calendar.Core.Logic.Storage;
using Catharsium.Util.IO.Interfaces;
using Catharsium.Util.Testing.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Collections.Generic;

namespace Catharsium.Calendar.Core.Logic.Tests._Configuration
{
    [TestClass]
    public class CalendarCoreLogicRegistrationTests
    {
        [TestMethod]
        public void AddCalendarCoreLogic_RegistersDependencies()
        {
            var serviceCollection = Substitute.For<IServiceCollection>();
            var configuration = Substitute.For<IConfiguration>();

            serviceCollection.AddCalendarCoreLogic(configuration);
            serviceCollection.ReceivedRegistration<ICalendarStorage>();
            serviceCollection.ReceivedRegistration<ICalendarImporter, CalendarImporter>();
            serviceCollection.ReceivedRegistration<IConsoleColorFactory, ConsoleColorFactory>();

            serviceCollection.ReceivedRegistration<StartDateEventFilter, StartDateEventFilter>();
            serviceCollection.ReceivedRegistration<EndDateEventFilter, EndDateEventFilter>();
            serviceCollection.ReceivedRegistration<DescriptionEventFilter, DescriptionEventFilter>();
            serviceCollection.ReceivedRegistration<LocationEventFilter, LocationEventFilter>();
            serviceCollection.ReceivedRegistration<SummaryEventFilter, SummaryEventFilter>();
            serviceCollection.ReceivedRegistration<OrEventFilter, OrEventFilter>();
            serviceCollection.ReceivedRegistration<IEventFilterFactory, EventFilterFactory>();

            serviceCollection.ReceivedRegistration<IEqualityComparer<Event>, EventEqualityComparer>();
        }


        [TestMethod]
        public void AddCalendarCoreLogic_RegistersPackages()
        {
            var serviceCollection = Substitute.For<IServiceCollection>();
            var configuration = Substitute.For<IConfiguration>();

            serviceCollection.AddCalendarCoreLogic(configuration);
            serviceCollection.ReceivedRegistration<IFileFactory>();
        }
    }
}