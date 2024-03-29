﻿using Catharsium.External.GoogleCalendar.Client.Models;
using Catharsium.Util.Interfaces;
using System;

namespace Catharsium.Calendar.Core.Logic.Interfaces;

public interface IEventFilterFactory
{
    IFilter<Event> CreateOrFilter(params IFilter<Event>[] filters);
    IFilter<Event> CreateStartDateFilter(DateTime from, DateTime to);
    IFilter<Event> CreateEndDateFilter(DateTime from, DateTime to);
    IFilter<Event> CreateDescriptionFilter(string query, bool ignoreCase = true);
    IFilter<Event> CreateLocationFilter(string query, bool ignoreCase = true);
    IFilter<Event> CreateSummaryFilter(string query, bool ignoreCase = true);
}