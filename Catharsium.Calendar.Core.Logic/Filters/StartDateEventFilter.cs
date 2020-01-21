using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Util.Filters;
using System;

namespace Catharsium.Calendar.Core.Logic.Filters
{
    public class StartDateEventFilter : IFilter<Event>
    {
        private readonly DateTime from;
        private readonly DateTime to;


        public StartDateEventFilter(DateTime from, DateTime to)
        {
            this.from = from;
            this.to = to;
        }


        public bool Includes(Event item)
        {
            var fromDate = this.from;
            var untilDate = this.to;

            if (item.Start.HasTime) {
                return item.Start.Value >= fromDate && item.Start.Value <= untilDate;
            }

            fromDate = fromDate.Date;
            untilDate = untilDate.Date;
            return item.Start.Value.Date >= fromDate && item.Start.Value.Date <= untilDate;
        }
    }
}