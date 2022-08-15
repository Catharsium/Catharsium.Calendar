using Catharsium.Calendar.Core.Entities.Models.Comparers;
using Catharsium.Calendar.Core.Logic.Filters;
using Catharsium.Calendar.Core.Logic.Interfaces;
using Catharsium.Calendar.Core.Logic.Presentation;
using Catharsium.Calendar.Core.Logic.Scheduler;
using Catharsium.Calendar.Core.Logic.Storage;
using Catharsium.External.GoogleCalendar.Client.Models;
using Catharsium.Util.Configuration.Extensions;
using Catharsium.Util.IO._Configuration;
using Catharsium.Util.IO.Interfaces;
using Catharsium.Util.IO.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Catharsium.Calendar.Core.Logic._Configuration;

public static class CalendarGoogleRegistration
{
    public static IServiceCollection AddCalendarCoreLogic(this IServiceCollection services, IConfiguration config) {
        var configuration = config.Load<CalendarCoreLogicSettings>();
        services.AddSingleton<CalendarCoreLogicSettings, CalendarCoreLogicSettings>(provider => configuration);

        services.AddIoUtilities(config);

        services.AddScoped<IJsonFileRepository<Event>>(s => {
            return new JsonFileRepository<Event>(
                s.GetService<IFileFactory>(),
                s.GetService<IJsonFileReader>(),
                s.GetService<IJsonFileWriter>(),
                configuration.SerializationFolder);
        });
        services.AddScoped<ICalendarImporter, CalendarImporter>();
        services.AddScoped<IConsoleColorFactory, ConsoleColorFactory>();

        services.AddScoped<IAppointmentGenerator, SingleAppointmentGenerator>();
        services.AddScoped<IAppointmentGenerator, DailyAppointmentGenerator>();
        services.AddScoped<IAppointmentGenerator, MonthlyAppointmentGenerator>();

        services.AddTransient<StartDateEventFilter, StartDateEventFilter>();
        services.AddTransient<EndDateEventFilter, EndDateEventFilter>();
        services.AddTransient<DescriptionEventFilter, DescriptionEventFilter>();
        services.AddTransient<LocationEventFilter, LocationEventFilter>();
        services.AddTransient<SummaryEventFilter, SummaryEventFilter>();
        services.AddTransient<OrEventFilter, OrEventFilter>();
        services.AddTransient<IEventFilterFactory, EventFilterFactory>();

        services.AddScoped<IEqualityComparer<Event>, EventEqualityComparer>();
        services.AddScoped<IAppointmentScheduler, AppointmentScheduler>();
        services.AddScoped<ITemplateScheduler, TemplateScheduler>();

        return services;
    }
}