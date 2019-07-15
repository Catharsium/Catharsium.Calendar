using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.Core.Logic._Configuration;
using Catharsium.Calendar.Core.Logic.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Catharsium.Calendar.Core.Logic.Storage
{
    public class JsonEventRepository : IEventRepository
    {
        private readonly JsonSerializer jsonSerializer;
        private readonly CalendarCoreLogicConfiguration options;


        public JsonEventRepository(JsonSerializer jsonSerializer, CalendarCoreLogicConfiguration options)
        {
            this.jsonSerializer = jsonSerializer;
            this.options = options;
        }


        public IEnumerable<Event> Load(string fileName)
        {
            using (var file = File.OpenText($@"{this.options.SerializationFolder}\{fileName}.json")) {
                return (IEnumerable<Event>)this.jsonSerializer.Deserialize(file, typeof(IEnumerable<Event>));
            }
        }


        public void Store(IEnumerable<Event> events, string fileName)
        {
            using (var file = File.CreateText($@"{this.options.SerializationFolder}\{fileName}.json")) {
                this.jsonSerializer.Serialize(file, events);
            }
        }
    }
}