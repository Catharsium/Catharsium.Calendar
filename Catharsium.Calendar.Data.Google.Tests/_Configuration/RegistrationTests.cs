using Catharsium.Clients.GoogleCalendar._Configuration;
using Catharsium.Clients.GoogleCalendar.Client.Services;
using Catharsium.Clients.GoogleCalendar.Interfaces;
using Catharsium.Util.Testing.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Clients.GoogleCalendar.Tests._Configuration;

[TestClass]
public class RegistrationTests
{
    [TestMethod]
    public void AddGoogleCalendar_RegistersDependencies()
    {
        var services = Substitute.For<IServiceCollection>();
        var configuration = Substitute.For<IConfiguration>();

        services.AddGoogleCalendarClient(configuration);
        services.ReceivedRegistration<ICalendarClientFactory>();
        services.ReceivedRegistration<IGoogleCalendarService, GoogleCalendarService>();
        services.ReceivedRegistration<IEventManagementService, GoogleEventManagementService>();
        services.ReceivedRegistration<IEventUpdateService, GoogleEventUpdateService>();
    }
}