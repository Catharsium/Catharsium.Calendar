using Catharsium.Calendar.Core.Logic.Interfaces;
using Catharsium.Calendar.Core.Logic.Storage;
using Catharsium.Util.Configuration.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Catharsium.Calendar.Core.Logic._Configuration
{
    public static class CalendarGoogleRegistration
    {
        public static IServiceCollection AddCalendarCoreLogic(this IServiceCollection services, IConfiguration config)
        {
            var configuration = config.Load<CalendarCoreLogicConfiguration>();
            services.AddScoped<IEventRepository>(s => new JsonEventRepository(new JsonSerializer {Formatting = Formatting.Indented}, configuration));

            return services;
        }
    }
}