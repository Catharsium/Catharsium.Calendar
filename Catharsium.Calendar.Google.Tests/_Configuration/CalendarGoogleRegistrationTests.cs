using Catharsium.Calendar.Core.Entities.Interfaces.Services;
using Catharsium.Calendar.Google._Configuration;
using Catharsium.Calendar.Google.Client.Services;
using Catharsium.Calendar.Google.Interfaces;
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
            var services = Substitute.For<IServiceCollection>();
            var configuration = Substitute.For<IConfiguration>();

            services.AddGoogleCalendar(configuration);
            services.ReceivedRegistration<ICalendarClientFactory>();
            services.ReceivedRegistration<ICalendarService, GoogleCalendarService>();
            services.ReceivedRegistration<IEventManagementService, GoogleEventManagementService>();
            services.ReceivedRegistration<IEventUpdateService, GoogleEventUpdateService>();
        }
    }
}