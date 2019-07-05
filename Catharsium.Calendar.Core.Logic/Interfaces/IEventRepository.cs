using System.Collections.Generic;
using Catharsium.Calendar.Core.Entities.Models;

namespace Catharsium.Calendar.Core.Logic.Interfaces
{
    public interface IEventRepository
    {
        IEnumerable<Event> Load();
        void Store(IEnumerable<Event> events);
    }
}