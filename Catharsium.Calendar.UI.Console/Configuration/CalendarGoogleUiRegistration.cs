using Catharsium.Calendar.Google._Configuration;
using Catharsium.Util.Configuration.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catharsium.Calendar.UI.Console.Configuration
{
    public static class CalendarGoogleUiRegistration
    {
        public static IServiceCollection AddGoogleCalendarConsoleUi(this IServiceCollection services, IConfiguration config)
        {
            var configuration = config.Load<CalendarGoogleUiConfiguration>();

            services.AddGoogleCalendar(config);

            return services;
        }
    }
}