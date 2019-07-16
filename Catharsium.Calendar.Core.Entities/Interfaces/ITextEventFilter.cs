using System.Collections.Generic;
using Catharsium.Calendar.Core.Entities.Models;

namespace Catharsium.Calendar.Core.Entities.Interfaces
{
    public interface ITextEventFilter
    {
        IEnumerable<Event> Apply(IEnumerable<Event> events, string text);
    }
}