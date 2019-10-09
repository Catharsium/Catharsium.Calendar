﻿using Catharsium.Calendar.Core.Logic.Interfaces;
using Catharsium.Calendar.UI.Console.Interfaces;
using System;

namespace Catharsium.Calendar.UI.Console.ActionHandlers
{
    public class ImportActionHandler : IImportActionHandler
    {
        private readonly ICalendarImporter calendarImporter;
        private readonly IChooseCalendarStepHandler chooseACalendarStepHandler;


        public ImportActionHandler(ICalendarImporter calendarImporter, IChooseCalendarStepHandler chooseACalendarStepHandler)
        {
            this.calendarImporter = calendarImporter;
            this.chooseACalendarStepHandler = chooseACalendarStepHandler;
        }


        public void Run()
        {
            var calendar = this.chooseACalendarStepHandler.Run();
            if (calendar == null) {
                return;
            }

            this.calendarImporter.Import(calendar.Id, new DateTime(2001, 1, 1), DateTime.Now.AddYears(1));
        }
    }
}