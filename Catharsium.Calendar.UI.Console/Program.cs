using Catharsium.Calendar.UI.Console._Configuration;
using Catharsium.Calendar.UI.Console.Enums;
using Catharsium.Calendar.UI.Console.Interfaces;
using Catharsium.Util.Enums;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace Catharsium.Calendar.UI.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, false);
            var configuration = builder.Build();

            var serviceProvider = new ServiceCollection()
                .AddLogging(configure => configure.AddConsole())
                .AddGoogleCalendarConsoleUi(configuration)
                .BuildServiceProvider();

            var importActionHandler = serviceProvider.GetService<IImportActionHandler>();
            var loadActionHandler = serviceProvider.GetService<ILoadActionHandler>();
            var searchActionHandler = serviceProvider.GetService<ISearchActionHandler>();

            while (true) {
                System.Console.WriteLine("Choose an action:");

                var actions = Enum.GetValues(typeof(UserActions));
                foreach (int action in actions) {
                    System.Console.WriteLine($"[{action}] {Enum.GetName(typeof(UserActions), action)}");
                }

                var requestedIndex = System.Console.ReadLine();

                if (requestedIndex == null || requestedIndex.ToLower() == "q") {
                    break;
                }

                var requestedAction = requestedIndex.ParseEnum(UserActions.Quit);
                if (requestedAction == UserActions.Quit) {
                    break;
                }

                switch (requestedAction) {
                    case UserActions.Import:
                        importActionHandler.Run();
                        break;
                    case UserActions.Load:
                        loadActionHandler.Run();
                        break;
                    case UserActions.Search:
                        searchActionHandler.Run();
                        break;
                    case UserActions.Quit:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}