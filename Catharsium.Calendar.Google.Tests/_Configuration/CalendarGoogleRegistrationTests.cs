using Catharsium.Calendar.Core.Entities.Interfaces;
using Catharsium.Calendar.Google._Configuration;
using Catharsium.Calendar.Google.Client.Services;
using Catharsium.Util.Testing.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Calendar.Google.Tests._Configuration
{
    [TestClass]
    public class CalendarGoogleRegistrationTests
    {
        [TestMethod]
        public void AddGoogleCalendar_RegistersDependencies()
        {
            var serviceCollection = Substitute.For<IServiceCollection>();
            var configuration = Substitute.For<IConfiguration>();

            serviceCollection.AddGoogleCalendar(configuration);
            serviceCollection.ReceivedRegistration<ICalendarClientFactory>();
            serviceCollection.ReceivedRegistration<ICalendarService, GoogleCalendarService>();
            serviceCollection.ReceivedRegistration<IEventService, GoogleEventService>();
        }
    }
}