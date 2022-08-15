using Catharsium.Calendar.Core.Logic.Interfaces;
using Catharsium.Calendar.UI.Console._Configuration;
using Catharsium.Util.IO.Console.ActionHandlers.Base;
using Catharsium.Util.IO.Console.Interfaces;
using System;
using System.Threading.Tasks;

namespace Catharsium.Calendar.UI.Console.ActionHandlers;

public class ScheduleActionHandler : BaseActionHandler
{
    private readonly IAppointmentScheduler appointmentScheduler;
    private readonly CalendarUiConsoleSettings configuration;


    public ScheduleActionHandler(IAppointmentScheduler appointmentScheduler, CalendarUiConsoleSettings configuration, IConsole console)
        : base(console, "Schedule period")
    {
        this.appointmentScheduler = appointmentScheduler;
        this.configuration = configuration;
    }


    public override async Task Run()
    {
        var startDate = this.console.AskForDate("Enter the start date (yyyy MM dd)");
        var endDate = this.console.AskForDate("Enter the end date (yyyy MM dd)");

        if(!startDate.HasValue) {
            startDate = DateTime.Today;
        }

        if(!endDate.HasValue) {
            endDate = startDate.Value.AddDays(7);
        }

        var events = await this.appointmentScheduler.GenerateFor(startDate.Value, endDate.Value, this.configuration.SchedulerSettings);
        foreach(var @event in events) {
            this.console.WriteLine($"{@event.Start.Value:yyyy-MM-dd}: \"{@event.Summary}\"");
        }
    }
}