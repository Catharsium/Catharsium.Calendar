using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Util.Interfaces;
namespace Catharsium.Calendar.Core.Logic.Filters;

public class LocationEventFilter : IFilter<Event>
{
    public string Query { get; set; }
    public bool IgnoreCase { get; set; }


    public bool Includes(Event item)
    {
        return this.IgnoreCase
            ? item.Location != null && item.Location.ToLower().Contains(this.Query.ToLower())
            : item.Location != null && item.Location.Contains(this.Query);
    }
}