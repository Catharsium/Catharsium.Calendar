﻿using Catharsium.External.GoogleCalendar.Client.Models;
using Catharsium.Util.Interfaces;

namespace Catharsium.Calendar.Core.Logic.Filters;

public class SummaryEventFilter : IFilter<Event>
{
    public string Query { get; set; }
    public bool IgnoreCase { get; set; }


    public bool Includes(Event item) {
        return this.IgnoreCase
            ? item.Summary != null && item.Summary.ToLower().Contains(this.Query.ToLower())
            : item.Summary != null && item.Summary.Contains(this.Query);
    }
}