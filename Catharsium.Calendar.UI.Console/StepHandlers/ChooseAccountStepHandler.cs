using Catharsium.Calendar.Data.Google.Interfaces;
using Catharsium.Calendar.UI.Console.Interfaces;
using Catharsium.Util.IO.Console.Interfaces;

namespace Catharsium.Calendar.UI.Console.StepHandlers
{
    public class ChooseAccountStepHandler : IChooseAccountStepHandler
    {
        private readonly string[] userNames;
        private readonly IConsole console;


        public ChooseAccountStepHandler(IConsole console, ICalendarClientFactory calendarClientFactory)
        {
            this.userNames = calendarClientFactory.GetUserNames();
            this.console = console;
        }


        public string Run()
        {
            this.console.WriteLine("Choose an account:");
            for (var i = 0; i < this.userNames.Length; i++) {
                this.console.WriteLine($"[{i + 1}] {this.userNames[i]}");
            }

            var accountIndex = this.console.AskForInt();
            if (accountIndex.HasValue && accountIndex > 0 && accountIndex <= this.userNames.Length) {
                return this.userNames[accountIndex.Value - 1];
            }

            return null;
        }
    }
}