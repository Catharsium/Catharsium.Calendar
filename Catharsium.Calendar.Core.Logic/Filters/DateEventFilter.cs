using Catharsium.Calendar.Core.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Catharsium.Calendar.Core.Entities.Interfaces.Filters;

namespace Catharsium.Calendar.Core.Logic.Filters
{
    public class DateEventFilter : IDateEventFilter
    {
        public IEnumerable<Event> ApplyToStartDate(IEnumerable<Event> events, DateTime from, DateTime until)
        {
            return events.Where(e => {
                var fromDate = from;
                var untilDate = until;

                if (!e.Start.HasTime) {
                    fromDate = fromDate.Date;
                    untilDate = untilDate.Date;
                }

                return e.Start.Value >= fromDate && e.Start.Value <= untilDate;
            });
        }
    }
}