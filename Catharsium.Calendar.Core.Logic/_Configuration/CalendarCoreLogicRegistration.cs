﻿using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.Core.Entities.Models.Comparers;
using Catharsium.Calendar.Core.Logic.Filters;
using Catharsium.Calendar.Core.Logic.Interfaces;
using Catharsium.Calendar.Core.Logic.Storage;
using Catharsium.Util.Configuration.Extensions;
using Catharsium.Util.Filters;
using Catharsium.Util.IO._Configuration;
using Catharsium.Util.IO.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Catharsium.Calendar.Core.Logic._Configuration
{
    public static class CalendarGoogleRegistration
    {
        public static IServiceCollection AddCalendarCoreLogic(this IServiceCollection services, IConfiguration config)
        {
            var configuration = config.Load<CalendarCoreLogicConfiguration>();

            services.AddIoUtilities(config);

            services.AddScoped<ICalendarStorage>(s =>
                new JsonCalendarStorage(s.GetService<IFileFactory>(),
                    new JsonSerializer {Formatting = Formatting.Indented},
                    configuration)
            );
            services.AddScoped<ICalendarImporter, CalendarImporter>();
            services.AddScoped<IFilter<Event>, StartDateEventFilter>();
            services.AddScoped<IFilter<Event>, EndDateEventFilter>();
            services.AddScoped<IFilter<Event>, DescriptionEventFilter>();
            services.AddScoped<IFilter<Event>, LocationEventFilter>();
            services.AddScoped<IFilter<Event>, SummaryEventFilter>();

            services.AddScoped<IEqualityComparer<Event>, EventEqualityComparer>();

            return services;
        }
    }
}