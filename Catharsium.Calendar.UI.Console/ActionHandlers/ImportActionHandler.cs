using Catharsium.Calendar.Core.Logic.Interfaces;
using Catharsium.Calendar.UI.Console.Interfaces;
using System;

namespace Catharsium.Calendar.UI.Console.ActionHandlers
{
    public class ImportActionHandler : IImportActionHandler
    {
        private readonly ICalendarImporter calendarImporter;
        private readonly IChooseACalendarStepHandler chooseACalendarStepHandler;


        public ImportActionHandler(ICalendarImporter calendarImporter, IChooseACalendarStepHandler chooseACalendarStepHandler)
        {
            this.calendarImporter = calendarImporter;
            this.chooseACalendarStepHandler = chooseACalendarStepHandler;
        }


        public void Run()
        {
            var calendar = this.chooseACalendarStepHandler.ChooseACalendar();
            if (calendar == null) {
                return;
            }

            this.calendarImporter.Import(calendar.Id, new DateTime(2001, 1, 1), DateTime.Now);
        }
    }
}