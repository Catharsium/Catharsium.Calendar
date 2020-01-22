using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Util.Filters;

namespace Catharsium.Calendar.Core.Logic.Filters
{
    public class SummaryEventFilter : IFilter<Event>
    {
        public string Query { get; set; }
        public bool IgnoreCase { get; set; }


        public bool Includes(Event item)
        {
            if (this.IgnoreCase) {
                return item.Summary != null && item.Summary.ToLower().Contains(this.Query.ToLower());
            }

            return item.Summary != null && item.Summary.Contains(this.Query);
        }
    }
}