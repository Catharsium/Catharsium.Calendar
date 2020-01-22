using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Util.Filters;

namespace Catharsium.Calendar.Core.Logic.Filters
{
    public class LocationEventFilter : IFilter<Event>
    {
        public string Query { get; set; }
        public bool IgnoreCase { get; set; }


        public bool Includes(Event item)
        {
            if (this.IgnoreCase) {
                return item.Location != null && item.Location.ToLower().Contains(this.Query.ToLower());
            }

            return item.Location != null && item.Location.Contains(this.Query);
        }
    }
}