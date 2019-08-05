using System;

namespace Catharsium.Calendar.Core.Logic.Interfaces
{
    public interface ICalendarImporter
    {
        void Import(string calendarId, DateTime startDate, DateTime endDate);
    }
}