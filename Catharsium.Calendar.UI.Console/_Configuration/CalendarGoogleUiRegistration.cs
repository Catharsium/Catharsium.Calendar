using Catharsium.Calendar.Core.Logic._Configuration;
using Catharsium.Calendar.Google._Configuration;
using Catharsium.Calendar.UI.Console.ActionHandlers;
using Catharsium.Calendar.UI.Console.Interfaces;
using Catharsium.Calendar.UI.Console.StepHandlers;
using Catharsium.Util.Configuration.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catharsium.Calendar.UI.Console._Configuration
{
    public static class CalendarGoogleUiRegistration
    {
        public static IServiceCollection AddGoogleCalendarConsoleUi(this IServiceCollection services, IConfiguration config)
        {
            var configuration = config.Load<CalendarGoogleUiConfiguration>();

            services.AddGoogleCalendar(config);
            services.AddCalendarCoreLogic(config);

            services.AddScoped<IImportActionHandler, ImportActionHandler>();
            services.AddScoped<ILoadActionHandler, LoadActionHandler>();
            services.AddScoped<ISearchActionHandler, SearchActionHandler>();
            services.AddScoped<ICreateEventActionHandler, CreateEventActionHandler>();
            services.AddScoped<IMoveEventActionHandler, MoveEventActionHandler>();

            services.AddScoped<IShowEventsStepHandler, ShowEventsStepHandler>();
            services.AddScoped<IChooseCalendarStepHandler, ChooseCalendarStepHandler>();
            services.AddScoped<IChooseEventStepHandler, ChooseEventStepHandler>();
            services.AddScoped<IChooseAccountStepHandler, ChooseAccountStepHandler>();

            return services;
        }
    }
}