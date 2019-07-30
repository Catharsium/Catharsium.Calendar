using Catharsium.Calendar.Google.Interfaces;
using Catharsium.Calendar.UI.Console.Interfaces;

namespace Catharsium.Calendar.UI.Console.StepHandlers
{
    public class ChooseAccountStepHandler : IChooseAccountStepHandler
    {
        private readonly string[] userNames;


        public ChooseAccountStepHandler(ICalendarClientFactory calendarClientFactory)
        {
            this.userNames = calendarClientFactory.GetUserNames();
        }


        public string Run()
        {
            System.Console.WriteLine("Choose an account:");
            for (var i = 0; i < this.userNames.Length; i++)
            {
                System.Console.WriteLine($"[{i + 1}] {this.userNames[i]}");
            }

            var requestedIndex = System.Console.ReadLine();
            if (int.TryParse(requestedIndex, out var accountIndex))
            {
                return this.userNames[accountIndex - 1];
            }

            return this.userNames[0];
        }
    }
}