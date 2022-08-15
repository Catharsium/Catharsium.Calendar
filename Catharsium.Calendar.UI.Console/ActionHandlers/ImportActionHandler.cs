using Catharsium.Calendar.Core.Logic.Interfaces;
using Catharsium.Calendar.UI.Console.Interfaces;
using Catharsium.Util.IO.Console.ActionHandlers.Base;
using Catharsium.Util.IO.Console.Interfaces;
using System;
using System.Threading.Tasks;

namespace Catharsium.Calendar.UI.Console.ActionHandlers;

public class ImportActionHandler : BaseActionHandler
{
    private readonly ICalendarImporter calendarImporter;
    private readonly IChooseCalendarStepHandler chooseACalendarStepHandler;


    public ImportActionHandler(
        ICalendarImporter calendarImporter,
        IChooseCalendarStepHandler chooseACalendarStepHandler,
        IConsole console)
        : base(console, "Import")
    {
        this.calendarImporter = calendarImporter;
        this.chooseACalendarStepHandler = chooseACalendarStepHandler;
    }


    public override async Task Run()
    {
        var calendar = await this.chooseACalendarStepHandler.Run();
        if(calendar == null) {
            return;
        }

        await this.calendarImporter.Import(calendar.Id, new DateTime(2001, 1, 1), DateTime.Now.AddYears(1));
    }
}