using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Util.Interfaces;
using System;
namespace Catharsium.Calendar.Core.Logic.Filters;

public class EndDateEventFilter : IFilter<Event>
{
    public DateTime From { get; set; }
    public DateTime To { get; set; }


    public bool Includes(Event item)
    {
        var fromDate = this.From;
        var untilDate = this.To;

        if (item.End.HasTime) {
            return item.End.Value >= fromDate && item.End.Value <= untilDate;
        }

        fromDate = fromDate.Date;
        untilDate = untilDate.Date;
        return item.End.Value.Date >= fromDate && item.End.Value.Date <= untilDate;
    }
}