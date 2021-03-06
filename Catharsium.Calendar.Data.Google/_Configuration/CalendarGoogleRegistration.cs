﻿using AutoMapper;
using Catharsium.Calendar.Core.Entities.Interfaces.Services;
using Catharsium.Calendar.Data.Google._Configuration.AutoMapper;
using Catharsium.Calendar.Data.Google.Client;
using Catharsium.Calendar.Data.Google.Client.Services;
using Catharsium.Calendar.Data.Google.Interfaces;
using Catharsium.Util.Configuration.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catharsium.Calendar.Data.Google._Configuration
{
    public static class CalendarGoogleRegistration
    {
        public static IServiceCollection AddGoogleCalendar(this IServiceCollection services, IConfiguration config)
        {
            var configuration = config.Load<CalendarGoogleConfiguration>();

            services.AddScoped<ICalendarClientFactory>(s => new GoogleCalendarClientFactory(configuration.Credentials));
            services.AddScoped<ICalendarService, GoogleCalendarService>();
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
}