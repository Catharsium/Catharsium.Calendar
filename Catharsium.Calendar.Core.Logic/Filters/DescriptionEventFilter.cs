using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Util.Filters;

namespace Catharsium.Calendar.Core.Logic.Filters
{
    public class DescriptionEventFilter : IFilter<Event>
    {
        public string Query { get; set; }
        public bool IgnoreCase { get; set; }


        public bool Includes(Event item)
        {
            if (this.IgnoreCase) {
                return item.Description != null && item.Description.ToLower().Contains(this.Query.ToLower());
            }

            return item.Description != null && item.Description.Contains(this.Query);
        }
    }
}