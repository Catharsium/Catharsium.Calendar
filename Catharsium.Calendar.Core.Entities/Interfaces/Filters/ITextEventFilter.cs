using System.Collections.Generic;
using Catharsium.Calendar.Core.Entities.Models;

namespace Catharsium.Calendar.Core.Entities.Interfaces.Filters
{
    public interface ITextEventFilter
    {
        IEnumerable<Event> ApplyToSummary(IEnumerable<Event> events, string text);
        IEnumerable<Event> ApplyToDescription(IEnumerable<Event> events, string text);
        IEnumerable<Event> ApplyToLocation(IEnumerable<Event> events, string text);
    }
}