using Catharsium.External.GoogleCalendar.Client.Models;
using System.Collections.Generic;

namespace Catharsium.Calendar.Core.Entities.Models.Comparers;

public class EventEqualityComparer : IEqualityComparer<Event>
{
    public bool Equals(Event x, Event y) {
        return x != null
            && y != null
            && x.Id == y.Id;
    }


    public int GetHashCode(Event obj) {
        return obj.GetHashCode();
    }
}