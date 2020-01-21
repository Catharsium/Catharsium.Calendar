using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Util.Filters;

namespace Catharsium.Calendar.Core.Logic.Filters
{
    public class LocationEventFilter : IFilter<Event>
    {
        private readonly string query;
        private readonly bool ignoreCase;


        public LocationEventFilter(string query, bool ignoreCase = true)
        {
            this.query = query;
            this.ignoreCase = ignoreCase;
        }


        public bool Includes(Event item)
        {
            if (this.ignoreCase) {
                return item.Location != null && item.Location.ToLower().Contains(this.query.ToLower());
            }

            return item.Location != null && item.Location.Contains(this.query);
        }
    }
}