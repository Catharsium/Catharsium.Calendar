using System;
using System.Threading.Tasks;

namespace Catharsium.Calendar.Core.Logic.Interfaces;

public interface ICalendarImporter
{
    Task Import(string calendarId, DateTime startDate, DateTime endDate);
}