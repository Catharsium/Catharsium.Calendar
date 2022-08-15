using Catharsium.Clients.GoogleCalendar.Models;
using Catharsium.Util.Interfaces;

namespace Catharsium.Calendar.Core.Logic.Filters;

public class DescriptionEventFilter : IFilter<Event>
{
    public string Query { get; set; }
    public bool IgnoreCase { get; set; }


    public bool Includes(Event item)
    {
        return this.IgnoreCase
            ? item.Description != null && item.Description.ToLower().Contains(this.Query.ToLower())
            : item.Description != null && item.Description.Contains(this.Query);
    }
}