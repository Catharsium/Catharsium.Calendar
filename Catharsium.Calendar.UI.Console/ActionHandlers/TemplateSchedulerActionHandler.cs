using Catharsium.Calendar.Core.Logic.Interfaces;
using Catharsium.Calendar.UI.Console._Configuration;
using Catharsium.Util.IO.Console.ActionHandlers.Base;
using Catharsium.Util.IO.Console.Interfaces;
using System;
using System.Threading.Tasks;

namespace Catharsium.Calendar.UI.Console.ActionHandlers;

public class TemplateSchedulerActionHandler : BaseActionHandler
{
    private readonly ITemplateScheduler templateScheduler;
    private readonly CalendarUiConsoleSettings configuration;

    public string FriendlyName => "Schedule template";


    public TemplateSchedulerActionHandler(ITemplateScheduler templateScheduler, IConsole console, CalendarUiConsoleSettings configuration)
        : base(console, "Schedule template")
    {
        this.templateScheduler = templateScheduler;
        this.configuration = configuration;
    }


    public override async Task Run()
    {
        var selectedTemplate = this.console.AskForItem(this.configuration.SchedulerSettings.Templates);
        var selectedDate = this.console.AskForDate("Specify the start date");
        var date = selectedDate ?? DateTime.Today;
        var selectedHour = this.console.AskForInt("Specify the start hour");
        var hour = selectedHour ?? 12;
        var selectedMinute = this.console.AskForInt("Specify the start minute");
        var minute = selectedMinute ?? 0;
        date = new DateTime(date.Year, date.Month, date.Day, hour, minute, 0);
        var scheduledAppointments = await this.templateScheduler.Schedule(date, selectedTemplate);
        foreach(var appointment in scheduledAppointments) {
            this.console.WriteLine($"{appointment.Summary} ({appointment.Start.Value:yyyy-MM-dd HH:mm})");
        }
    }
}