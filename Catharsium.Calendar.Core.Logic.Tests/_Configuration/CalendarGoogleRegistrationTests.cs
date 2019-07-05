﻿using Catharsium.Calendar.Core.Logic._Configuration;
using Catharsium.Calendar.Core.Logic.Interfaces;
using Catharsium.Util.Testing.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Calendar.Core.Logic.Tests._Configuration
{
    [TestClass]
    public class CalendarCoreLogicTests
    {
        [TestMethod]
        public void AddGoogleCalendar_RegistersDependencies()
        {
            var serviceCollection = Substitute.For<IServiceCollection>();
            var configuration = Substitute.For<IConfiguration>();

            serviceCollection.AddCalendarCoreLogic(configuration);
            serviceCollection.ReceivedRegistration<IEventRepository>();
        }
    }
}