using AutoMapper;
using Catharsium.Clients.GoogleCalendar.Models;
using System;
using System.Globalization;
using GoogleEventDateTime = Google.Apis.Calendar.v3.Data.EventDateTime;

namespace Catharsium.Clients.GoogleCalendar._Configuration.AutoMapper.Mappers;

public class DateMapper : IValueResolver<GoogleEventDateTime, Date, DateTime>
{
    public DateTime Resolve(GoogleEventDateTime source, Date destination, DateTime destMember, ResolutionContext context)
    {
        if(source.DateTime.HasValue) {
            destination.HasTime = true;
            destination.Value = source.DateTime.Value;
        }
        else if(DateTime.TryParseExact(source.Date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dateTime)) {
            destination.HasTime = false;
            destination.Value = dateTime;
        }

        return destination.Value;
    }
}