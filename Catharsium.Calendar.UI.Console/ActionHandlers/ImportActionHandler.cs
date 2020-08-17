using Catharsium.Calendar.Core.Logic.Interfaces;
using Catharsium.Calendar.UI.Console.Interfaces;
using Catharsium.Util.IO.Console.Interfaces;
using System;
using System.Threading.Tasks;

namespace Catharsium.Calendar.UI.Console.ActionHandlers
{
    public class ImportActionHandler : IActionHandler
    {
        private readonly ICalendarImporter calendarImporter;
        private readonly IChooseCalendarStepHandler chooseACalendarStepHandler;


        public string FriendlyName => "Import";


        public ImportActionHandler(ICalendarImporter calendarImporter, IChooseCalendarStepHandler chooseACalendarStepHandler)
        {
            this.calendarImporter = calendarImporter;
            this.chooseACalendarStepHandler = chooseACalendarStepHandler;
        }


        public async Task Run()
        {
            var calendar = await this.chooseACalendarStepHandler.Run();
            if (calendar == null) {
                return;
            }

            await this.calendarImporter.Import(calendar.Id, new DateTime(2001, 1, 1), DateTime.Now.AddYears(1));
        }
    }
}