using Catharsium.Calendar.Core.Entities.Interfaces.Filters;
using Catharsium.Calendar.Core.Entities.Models;
using System.Collections.Generic;
using System.Linq;

namespace Catharsium.Calendar.Core.Logic.Filters
{
    public class TextEventFilter : ITextEventFilter
    {
        public IEnumerable<Event> ApplyToSummary(IEnumerable<Event> events, string text)
        {
            return events.Where(e => e.Summary != null && e.Summary.ToLower().Contains(text.ToLower()));
        }


        public IEnumerable<Event> ApplyToDescription(IEnumerable<Event> events, string text)
        {
            return events.Where(e => e.Description != null && e.Description.ToLower().Contains(text.ToLower()));
        }


        public IEnumerable<Event> ApplyToLocation(IEnumerable<Event> events, string text)
        {
            return events.Where(e => e.Location != null && e.Location.ToLower().Contains(text.ToLower()));
        }
    }
}