using Catharsium.Calendar.Core.Logic._Configuration;
using Catharsium.Calendar.Data.Google._Configuration;
using Catharsium.Calendar.UI.Console.ActionHandlers;
using Catharsium.Calendar.UI.Console.Interfaces;
using Catharsium.Calendar.UI.Console.StepHandlers;
using Catharsium.Util.Configuration.Extensions;
using Catharsium.Util.IO.Console._Configuration;
using Catharsium.Util.IO.Console.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catharsium.Calendar.UI.Console._Configuration
{
    public static class CalendarGoogleUiRegistration
    {
        public static IServiceCollection AddGoogleCalendarConsoleUi(this IServiceCollection services, IConfiguration config)
        {
            var configuration = config.Load<CalendarGoogleUiConfiguration>();
            services.AddSingleton<CalendarGoogleUiConfiguration, CalendarGoogleUiConfiguration>(provider => configuration);

            services.AddConsoleIoUtilities(config);

            services.AddGoogleCalendar(config);
            services.AddCalendarCoreLogic(config);

            services.AddScoped<IActionHandler, ImportActionHandler>();
            services.AddScoped<IActionHandler, LoadActionHandler>();
            services.AddScoped<IActionHandler, SearchActionHandler>();
            services.AddScoped<IActionHandler, DeleteEventActionHandler>();
            services.AddScoped<IActionHandler, CreateEventActionHandler>();
            services.AddScoped<IActionHandler, MoveEventActionHandler>();
            services.AddScoped<IActionHandler, ScheduleActionHandler>();

            services.AddScoped<IShowEventsStepHandler, ShowEventsStepHandler>();
            services.AddScoped<IChooseCalendarStepHandler, ChooseCalendarStepHandler>();
            services.AddScoped<IChooseEventStepHandler, ChooseEventStepHandler>();
            services.AddScoped<IChooseAccountStepHandler, ChooseAccountStepHandler>();

            return services;
        }
    }
}