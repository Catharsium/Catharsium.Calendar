using AutoMapper;
using Catharsium.Calendar.Data.Google._Configuration;
using Catharsium.Clients.GoogleCalendar._Configuration.AutoMapper;
using Catharsium.Clients.GoogleCalendar.Client;
using Catharsium.Clients.GoogleCalendar.Client.Services;
using Catharsium.Clients.GoogleCalendar.Interfaces;
using Catharsium.Util.Configuration.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catharsium.Clients.GoogleCalendar._Configuration;

public static class CalendarGoogleRegistration
{
    public static IServiceCollection AddGoogleCalendar(this IServiceCollection services, IConfiguration config)
    {
        var configuration = config.Load<CalendarGoogleConfiguration>();

        services.AddScoped<ICalendarClientFactory>(s => new GoogleCalendarClientFactory(configuration.Credentials));
        services.AddScoped<IGoogleCalendarService, GoogleCalendarService>();
        services.AddScoped<IEventManagementService, GoogleEventManagementService>();
        services.AddScoped<IEventUpdateService, GoogleEventUpdateService>();

        var mappingConfig = new MapperConfiguration(mc => {
            mc.AddProfile(new GoogleToLocalMappingProfile());
            mc.AddProfile(new LocalToGoogleMappingProfile());
        });

        var mapper = mappingConfig.CreateMapper();
        services.AddSingleton(mapper);

        return services;
    }
}