using Catharsium.Calendar.Core.Logic._Configuration;
using Catharsium.Calendar.UI.Console.ActionHandlers;
using Catharsium.Calendar.UI.Console.Interfaces;
using Catharsium.Calendar.UI.Console.StepHandlers;
using Catharsium.External.GoogleCalendar.Client._Configuration;
using Catharsium.Util.Configuration.Extensions;
using Catharsium.Util.IO.Console._Configuration;
using Catharsium.Util.IO.Console.ActionHandlers.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catharsium.Calendar.UI.Console._Configuration;

public static class Registration
{
    public static IServiceCollection AddGoogleCalendarConsoleUi(this IServiceCollection services, IConfiguration config) {
        var configuration = config.Load<CalendarUiConsoleSettings>("Catharsium.Calendar.UI.Console");
        services.AddSingleton<CalendarUiConsoleSettings, CalendarUiConsoleSettings>(provider => configuration);

        services.AddConsoleIoUtilities(config);

        services.AddGoogleCalendarClient(config);
        services.AddCalendarCoreLogic(config);

        services.AddScoped<IActionHandler, ImportActionHandler>();
        services.AddScoped<IActionHandler, LoadActionHandler>();
        services.AddScoped<IActionHandler, SearchActionHandler>();
        services.AddScoped<IActionHandler, DeleteEventActionHandler>();
        services.AddScoped<IActionHandler, CreateEventActionHandler>();
        services.AddScoped<IActionHandler, MoveEventActionHandler>();
        services.AddScoped<IActionHandler, ScheduleActionHandler>();
        services.AddScoped<IActionHandler, TemplateSchedulerActionHandler>();

        services.AddScoped<IShowEventsStepHandler, ShowEventsStepHandler>();
        services.AddScoped<IChooseCalendarStepHandler, ChooseCalendarStepHandler>();
        services.AddScoped<IChooseEventStepHandler, ChooseEventStepHandler>();
        services.AddScoped<IChooseAccountStepHandler, ChooseAccountStepHandler>();

        return services;
    }
}