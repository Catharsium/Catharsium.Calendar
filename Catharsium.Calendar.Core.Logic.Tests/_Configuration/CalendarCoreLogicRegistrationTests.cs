using Catharsium.Calendar.Core.Entities.Interfaces;
using Catharsium.Calendar.Core.Entities.Interfaces.Filters;
using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.Core.Entities.Models.Comparers;
using Catharsium.Calendar.Core.Logic._Configuration;
using Catharsium.Calendar.Core.Logic.Actions;
using Catharsium.Calendar.Core.Logic.Filters;
using Catharsium.Calendar.Core.Logic.Interfaces;
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
        public void AddGoogleCalendar_RegistersDependencies()
        {
            var serviceCollection = Substitute.For<IServiceCollection>();
            var configuration = Substitute.For<IConfiguration>();

            serviceCollection.AddCalendarCoreLogic(configuration);
            serviceCollection.ReceivedRegistration<ICalendarImporter, CalendarImporter>();
            serviceCollection.ReceivedRegistration<IEventUpdater, EventUpdater>();
            serviceCollection.ReceivedRegistration<ICalendarStorage>();
            serviceCollection.ReceivedRegistration<ITextEventFilter, TextEventFilter>();

            serviceCollection.ReceivedRegistration<IEqualityComparer<Event>, EventEqualityComparer>();
        }


        [TestMethod]
        public void AddGoogleCalendar_RegistersPackages()
        {
            var serviceCollection = Substitute.For<IServiceCollection>();
            var configuration = Substitute.For<IConfiguration>();

            serviceCollection.AddCalendarCoreLogic(configuration);
            serviceCollection.ReceivedRegistration<IFileFactory>();
        }
    }
}