using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Util.Filters;

namespace Catharsium.Calendar.Core.Logic.Filters
{
    public class SummaryEventFilter : IFilter<Event>
    {
        private readonly string query;
        private readonly bool ignoreCase;


        public SummaryEventFilter(string query, bool ignoreCase = true)
        {
            this.query = query;
            this.ignoreCase = ignoreCase;
        }


        public bool Includes(Event item)
        {
            if (this.ignoreCase) {
                return item.Summary != null && item.Summary.ToLower().Contains(this.query.ToLower());
            }

            return item.Summary != null && item.Summary.Contains(this.query);
        }
    }
}