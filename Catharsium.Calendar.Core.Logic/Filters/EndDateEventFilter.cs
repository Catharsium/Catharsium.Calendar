using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Util.Filters;
using System;

namespace Catharsium.Calendar.Core.Logic.Filters
{
    public class EndDateEventFilter : IFilter<Event>
    {
        private readonly DateTime from;
        private readonly DateTime to;


        public EndDateEventFilter(DateTime from, DateTime to)
        {
            this.from = from;
            this.to = to;
        }


        public bool Includes(Event item)
        {
            var fromDate = this.from;
            var untilDate = this.to;

            if (item.End.HasTime) {
                return item.End.Value >= fromDate && item.End.Value <= untilDate;
            }

            fromDate = fromDate.Date;
            untilDate = untilDate.Date;
            return item.End.Value.Date >= fromDate && item.End.Value.Date <= untilDate;
        }
    }
}