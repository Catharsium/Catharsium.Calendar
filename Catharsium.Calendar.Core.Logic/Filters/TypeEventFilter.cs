using Catharsium.Calendar.Core.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Catharsium.Calendar.Core.Logic.Filters
{
    public class DateEventFilter
    {
        public IEnumerable<Event> ApplyStartDate(IEnumerable<Event> events, DateTime from, DateTime to)
        {
            throw new NotImplementedException();
           // return events.Where(e => e.Start.HasTime && e.Start);
        }
    }
}
