using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Util.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Catharsium.Calendar.Core.Logic.Filters
{
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
            if (!(this.CreateFilter<OrFilter>() is OrFilter result)) {
                return null;
            }

            result.Filters = filters.ToList();
            return result;
        }


        public IFilter<Event> CreateStartDateFilter(DateTime from, DateTime to)
        {
            if (!(this.CreateFilter<StartDateEventFilter>() is StartDateEventFilter result)) {
                return null;
            }

            result.From = from;
            result.To = to;
            return result;
        }


        public IFilter<Event> CreateEndDateFilter(DateTime from, DateTime to)
        {
            if (!(this.CreateFilter<EndDateEventFilter>() is EndDateEventFilter result)) {
                return null;
            }

            result.From = from;
            result.To = to;
            return result;
        }


        public IFilter<Event> CreateDescriptionFilter(string query, bool ignoreCase = true)
        {
            if (!(this.CreateFilter<DescriptionEventFilter>() is DescriptionEventFilter result)) {
                return null;
            }

            result.Query = query;
            result.IgnoreCase = ignoreCase;
            return result;
        }


        public IFilter<Event> CreateLocationFilter(string query, bool ignoreCase = true)
        {
            if (!(this.CreateFilter<LocationEventFilter>() is LocationEventFilter result)) {
                return null;
            }

            result.Query = query;
            result.IgnoreCase = ignoreCase;
            return result;
        }


        public IFilter<Event> CreateSummaryFilter(string query, bool ignoreCase = true)
        {
            if (!(this.CreateFilter<SummaryEventFilter>() is SummaryEventFilter result)) {
                return null;
            }

            result.Query = query;
            result.IgnoreCase = ignoreCase;
            return result;
        }
    }
}