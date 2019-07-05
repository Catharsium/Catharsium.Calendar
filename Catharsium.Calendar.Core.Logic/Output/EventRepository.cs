using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.Core.Logic._Configuration;
using Catharsium.Calendar.Core.Logic.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Catharsium.Calendar.Core.Logic.Output
{
    public class EventRepository : IEventRepository
    {
        private readonly JsonSerializer jsonSerializer;
        private readonly CalendarCoreLogicConfiguration options;


        public EventRepository(JsonSerializer jsonSerializer, CalendarCoreLogicConfiguration options)
        {
            this.jsonSerializer = jsonSerializer;
            this.options = options;
        }


        public IEnumerable<Event> Load()
        {
            throw new System.NotImplementedException();
        }


        public void Store(IEnumerable<Event> events)
        {
            using (var file = File.CreateText($"{this.options.SerializationFolder}\\\\test.json")) {
                this.jsonSerializer.Serialize(file, events);
            }
        }
    }
}