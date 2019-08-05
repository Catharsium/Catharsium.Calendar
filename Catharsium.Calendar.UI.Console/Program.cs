using Catharsium.Calendar.Google.Interfaces;
using Catharsium.Calendar.UI.Console._Configuration;
using Catharsium.Calendar.UI.Console.Enums;
using Catharsium.Calendar.UI.Console.Interfaces;
using Catharsium.Util.Enums;
using Catharsium.Util.IO.Interfaces;
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

            var console = serviceProvider.GetService<IConsole>();
            var importActionHandler = serviceProvider.GetService<IImportActionHandler>();
            var loadActionHandler = serviceProvider.GetService<ILoadActionHandler>();
            var searchActionHandler = serviceProvider.GetService<ISearchActionHandler>();
            var createEventActionHandler = serviceProvider.GetService<ICreateEventActionHandler>();
            var deleteEventActionHandler = serviceProvider.GetService<IDeleteEventActionHandler>();
            var moveEventActionHandler = serviceProvider.GetService<IMoveEventActionHandler>();
            var calendarClientFactory = serviceProvider.GetService<ICalendarClientFactory>();
            var chooseAccountStepHandler = serviceProvider.GetService<IChooseAccountStepHandler>();

            //var x = serviceProvider.GetService<IEventService>();
            //calendarClientFactory.UserName = "t.w.brachthuizer@gmail.com";
            //x.UpdateEvent("t.w.brachthuizer@gmail.com", new Core.Entities.Models.Event {
            //    Id = "7p7316d2cn5iu3lf64h6uurmob",
            //    CalendarId = "t.w.brachthuizer@gmail.com",
            //    ICalUID = "7p7316d2cn5iu3lf64h6uurmob@google.com",
            //    ETag = "\"3128761098970000\"",
            //    HtmlLink = "https://www.google.com/calendar/event?eid=N3A3MzE2ZDJjbjVpdTNsZjY0aDZ1dXJtb2IgdC53LmJyYWNodGh1aXplckBt",
            //    Start = new Core.Entities.Models.Date {
            //        HasTime = true,
            //        Value = DateTime.Now
            //    },
            //    End = new Core.Entities.Models.Date {
            //        HasTime = true,
            //        Value = DateTime.Now.AddHours(2)
            //    },
            //    Summary = "Test thierry",
            //    Organizer = new Core.Entities.Models.Person {
            //        Email = "t.w.brachthuizer@gmail.com",
            //    },
            //    Creator = new Core.Entities.Models.Person {
            //        Email = "t.w.brachthuizer@gmail.com",
            //    },
            //    Created = DateTime.Parse("2019-07-29T08:09:07+02:00"),
            //    Updated = DateTime.Parse("2019-07-29T08:09:09.485+02:00"),
            //    Sequence = 0,
            //    Status = "confirmed",
            //    Kind = "calendar#event",
            //    ColorId = "5",
            //    Location = null
            //});

            while (true) {
                console.WriteLine("Choose an action:");

                var actions = Enum.GetValues(typeof(UserActions));
                foreach (int action in actions) {
                    console.WriteLine($"[{action}] {Enum.GetName(typeof(UserActions), action)}");
                }

                var requestedIndex = console.AskForText();

                if (requestedIndex == null || requestedIndex.ToLower() == "q") {
                    break;
                }

                var requestedAction = requestedIndex.ParseEnum(UserActions.Quit);
                if (requestedAction == UserActions.Quit) {
                    break;
                }

                calendarClientFactory.UserName = chooseAccountStepHandler.Run();

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
                    case UserActions.Create:
                        createEventActionHandler.Run();
                        break;
                    case UserActions.Delete:
                        deleteEventActionHandler.Run();
                        break;
                    case UserActions.Move:
                        moveEventActionHandler.Run();
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