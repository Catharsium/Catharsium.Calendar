using Catharsium.Calendar.Core.Logic.Interfaces;
using Catharsium.Calendar.Core.Logic.Output;
using Catharsium.Util.Configuration.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Catharsium.Calendar.Core.Logic._Configuration
{
    public static class CalendarGoogleRegistration
    {
        public static IServiceCollection AddCalendarCoreLogic(this IServiceCollection services, IConfiguration config)
        {
            var configuration = config.Load<CalendarGoogleConfiguration>();

            services.AddScoped<IEventJsonSerializer>(s => new EventJsonSerializer(new JsonSerializer {Formatting = Formatting.Indented}));

            return services;
        }
    }
}