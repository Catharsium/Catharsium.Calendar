using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Util.Filters;
using System;

namespace Catharsium.Calendar.Core.Logic.Filters
{
    public class StartDateEventFilter : IFilter<Event>
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }


        public bool Includes(Event item)
        {
            var fromDate = this.From;
            var untilDate = this.To;

            if (item.Start.HasTime) {
                return item.Start.Value >= fromDate && item.Start.Value <= untilDate;
            }

            fromDate = fromDate.Date;
            untilDate = untilDate.Date;
            return item.Start.Value.Date >= fromDate && item.Start.Value.Date <= untilDate;
        }
    }
}