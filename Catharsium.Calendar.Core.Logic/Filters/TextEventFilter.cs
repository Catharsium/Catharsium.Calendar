using Catharsium.Calendar.Core.Entities.Models;
using System.Collections.Generic;
using System.Linq;
using Catharsium.Calendar.Core.Entities.Interfaces;

namespace Catharsium.Calendar.Core.Logic.Filters
{
    public class TextEventFilter : ITextEventFilter
    {
        public IEnumerable<Event> ApplyToSummary(IEnumerable<Event> events, string text)
        {
            return events.Where(e => e.Summary.Contains(text));
        }


        public IEnumerable<Event> ApplyToDescription(IEnumerable<Event> events, string text)
        {
            return events.Where(e => e.Description.Contains(text));
        }


        public IEnumerable<Event> ApplyToLocation(IEnumerable<Event> events, string text)
        {
            return events.Where(e => e.Location.Contains(text));
        }
    }
}