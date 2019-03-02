using Catharsium.Calendar.Google.Core.Entities.Interfaces;
using Catharsium.Util.Configuration.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catharsium.Calendar.Google.Configuration
{
    public static class CalendarGoogleRegistration
    {
        public static IServiceCollection AddGoogleCalendar(this IServiceCollection services, IConfiguration config)
        {
            var configuration = config.Load<CalendarGoogleConfiguration>();

            services.AddScoped<IGoogleCalendarServiceFactory>(s => new GoogleCalendarServiceFactory(configuration.ApplicationName));

            return services;
        }
    }
}