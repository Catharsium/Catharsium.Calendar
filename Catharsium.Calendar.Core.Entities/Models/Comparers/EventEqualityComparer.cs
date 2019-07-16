using System.Collections.Generic;

namespace Catharsium.Calendar.Core.Entities.Models.Comparers
{
    public class EventEqualityComparer : IEqualityComparer<Event>
    {
        public bool Equals(Event x, Event y)
        {
            if (x == null || y == null) {
                return false;
            }

            return x.Id == y.Id;
        }


        public int GetHashCode(Event obj)
        {
            return obj.GetHashCode();
        }
    }
}