using Catharsium.Calendar.Core.Logic.Interfaces;
using Catharsium.Clients.GoogleCalendar.Models;
using Catharsium.Util.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Catharsium.Calendar.Core.Logic.Filters;

public class EventFilterFactory : IEventFilterFactory
{
    private readonly IServiceProvider serviceProvider;


    public EventFilterFactory(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }


    public IFilter<Event> CreateFilter<TFilter>() where TFilter : IFilter<Event>
    {
        return this.serviceProvider.GetService<TFilter>();
    }


    public IFilter<Event> CreateOrFilter(params IFilter<Event>[] filters)
    {
        if(this.CreateFilter<OrEventFilter>() is not OrEventFilter result) {
            return null;
        }

        result.Filters = filters.ToList();
        return result;
    }


    public IFilter<Event> CreateStartDateFilter(DateTime from, DateTime to)
    {
        if(this.CreateFilter<StartDateEventFilter>() is not StartDateEventFilter result) {
            return null;
        }

        result.From = from;
        result.To = to;
        return result;
    }


    public IFilter<Event> CreateEndDateFilter(DateTime from, DateTime to)
    {
        if(this.CreateFilter<EndDateEventFilter>() is not EndDateEventFilter result) {
            return null;
        }

        result.From = from;
        result.To = to;
        return result;
    }


    public IFilter<Event> CreateDescriptionFilter(string query, bool ignoreCase = true)
    {
        if(this.CreateFilter<DescriptionEventFilter>() is not DescriptionEventFilter result) {
            return null;
        }

        result.Query = query;
        result.IgnoreCase = ignoreCase;
        return result;
    }


    public IFilter<Event> CreateLocationFilter(string query, bool ignoreCase = true)
    {
        if(this.CreateFilter<LocationEventFilter>() is not LocationEventFilter result) {
            return null;
        }

        result.Query = query;
        result.IgnoreCase = ignoreCase;
        return result;
    }


    public IFilter<Event> CreateSummaryFilter(string query, bool ignoreCase = true)
    {
        if(this.CreateFilter<SummaryEventFilter>() is not SummaryEventFilter result) {
            return null;
        }

        result.Query = query;
        result.IgnoreCase = ignoreCase;
        return result;
    }
}