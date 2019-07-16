using Catharsium.Calendar.Core.Entities.Models;
using System.Collections.Generic;
using System.Linq;
using Catharsium.Calendar.Core.Entities.Interfaces;

namespace Catharsium.Calendar.Core.Logic.Filters
{
    public class TextEventFilter : ITextEventFilter
    {
        public IEnumerable<Event> Apply(IEnumerable<Event> events, string text)
        {
            return events.Where(e => e.Summary.Contains(text) || e.Description.Contains(text) || e.Location.Contains(text));
        }
    }
}