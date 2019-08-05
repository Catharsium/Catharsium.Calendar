using System;
using System.Collections.Generic;
using Catharsium.Calendar.Core.Entities.Models;

namespace Catharsium.Calendar.Core.Entities.Interfaces.Filters
{
    public interface IDateEventFilter
    {
        IEnumerable<Event> ApplyToStartDate(IEnumerable<Event> events, DateTime from, DateTime until);
    }
}