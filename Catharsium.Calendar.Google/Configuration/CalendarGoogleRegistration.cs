using AutoMapper;
using Catharsium.Calendar.Core.Entities.Interfaces;
using Catharsium.Calendar.Google.Client;
using Catharsium.Calendar.Google.Configuration.AutoMapper;
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

            services.AddScoped<ICalendarClientFactory>(s => new GoogleCalendarClientFactory(configuration.CredentialsPath, configuration.ApplicationName, configuration.UserName));
            services.AddScoped<ICalendarClient, GoogleCalendarClient>();
            services.AddScoped<ICalendarService, GoogleCalendarService>();
            services.AddScoped<IEventService, GoogleEventService>();
            
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}