using AutoMapper;
using Catharsium.Calendar.Core.Entities.Interfaces;
using Catharsium.Calendar.Google._Configuration.AutoMapper;
using Catharsium.Calendar.Google.Client;
using Catharsium.Calendar.Google.Client.Services;
using Catharsium.Util.Configuration.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catharsium.Calendar.Google._Configuration
{
    public static class CalendarGoogleRegistration
    {
        public static IServiceCollection AddGoogleCalendar(this IServiceCollection services, IConfiguration config)
        {
            var configuration = config.Load<CalendarGoogleConfiguration>();

            services.AddScoped<ICalendarClientFactory>(s => new GoogleCalendarClientFactory(configuration.Credentials));
            services.AddScoped<ICalendarService, GoogleCalendarService>();
            services.AddScoped<IEventService, GoogleEventService>();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new GoogleToLocalMappingProfile());
            });

            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}