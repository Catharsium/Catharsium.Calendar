using System.Collections.Generic;
using Catharsium.Calendar.Core.Entities.Models;

namespace Catharsium.Calendar.Core.Logic.Interfaces
{
    public interface IEventJsonSerializer
    {
        void Serialize(IEnumerable<Event> events);
    }
}