using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Util.Filters;

namespace Catharsium.Calendar.Core.Logic.Filters
{
    public class DescriptionEventFilter : IFilter<Event>
    {
        private readonly string query;
        private readonly bool ignoreCase;


        public DescriptionEventFilter(string query, bool ignoreCase = true)
        {
            this.query = query;
            this.ignoreCase = ignoreCase;
        }


        public bool Includes(Event item)
        {
            if (this.ignoreCase) {
                return item.Description != null && item.Description.ToLower().Contains(this.query.ToLower());
            }

            return item.Description != null && item.Description.Contains(this.query);
        }
    }
}