using Catharsium.Calendar.Core.Logic.Interfaces;
using Catharsium.Calendar.UI.Console._Configuration;
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
            serviceCollection.ReceivedRegistration<IEventRepository>();
        }
    }
}