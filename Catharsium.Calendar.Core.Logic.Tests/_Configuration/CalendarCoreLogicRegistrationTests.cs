using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.Core.Entities.Models.Comparers;
using Catharsium.Calendar.Core.Logic._Configuration;
using Catharsium.Calendar.Core.Logic.Filters;
using Catharsium.Calendar.Core.Logic.Interfaces;
using Catharsium.Calendar.Core.Logic.Storage;
using Catharsium.Util.Filters;
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
            serviceCollection.ReceivedRegistration<ICalendarImporter, CalendarImporter>();
            serviceCollection.ReceivedRegistration<ICalendarStorage>();
            serviceCollection.ReceivedRegistration<IFilter<Event>, StartDateEventFilter>();
            serviceCollection.ReceivedRegistration<IFilter<Event>, EndDateEventFilter>();
            serviceCollection.ReceivedRegistration<IFilter<Event>, DescriptionEventFilter>();
            serviceCollection.ReceivedRegistration<IFilter<Event>, LocationEventFilter>();
            serviceCollection.ReceivedRegistration<IFilter<Event>, SummaryEventFilter>();

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