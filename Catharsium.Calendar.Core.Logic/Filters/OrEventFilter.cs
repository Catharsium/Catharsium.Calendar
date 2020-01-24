using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Util.Filters;
using System.Collections.Generic;
using System.Linq;

namespace Catharsium.Calendar.Core.Logic.Filters
{
    public class OrEventFilter : IFilter<Event>
    {
        public List<IFilter<Event>> Filters { get; set; }


        public bool Includes(Event @event)
        {
            return this.Filters.Any(f => f.Includes(@event));
        }
    }
}