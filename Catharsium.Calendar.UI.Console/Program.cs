using Catharsium.Calendar.UI.Console._Configuration;
using Catharsium.Calendar.UI.Console.Interfaces;
using Catharsium.Clients.GoogleCalendar.Interfaces;
using Catharsium.Util.IO.Console.ActionHandlers.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Threading.Tasks;
namespace Catharsium.Calendar.UI.Console;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false, false);
        var configuration = builder.Build();

        var serviceProvider = new ServiceCollection()
            .AddLogging(configure => configure.AddConsole())
            .AddGoogleCalendarConsoleUi(configuration)
            .BuildServiceProvider();

        var calendarClientFactory = serviceProvider.GetService<ICalendarClientFactory>();
        var chooseAccountStepHandler = serviceProvider.GetService<IChooseAccountStepHandler>();
        calendarClientFactory.UserName = chooseAccountStepHandler.Run();

        var chooseOperationActionHandler = serviceProvider.GetService<ISingleMenuActionHandler>();
        await chooseOperationActionHandler.Run();
    }
}